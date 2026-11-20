using maca_movie.Data;
using maca_movie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace maca_movie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly MovieDbContext _context;


        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
        }

     

        public async Task<IActionResult> Index(int page = 1, string txtBusqueda = "" , int IdGenero = 0, int IdPlataforma = 0)
        {
           
            const int pageSize = 6;
            page = Math.Max(page, 1);

            var genero = await _context.Generos
               .ToListAsync();
            var Plataforma = await _context.Plataformas
               .ToListAsync();

            var consulta = _context.Peliculas.AsQueryable();
            if (!string.IsNullOrEmpty(txtBusqueda))
            {
                consulta = consulta.Where(p => p.Nombre.Contains(txtBusqueda));
            }
            if(IdGenero > 0)
            {
                consulta = consulta.Where(p => p.GeneroId == IdGenero);

            }
            if(IdPlataforma > 0)
            {
                consulta = consulta.Where(p => p.PlataformaId == IdPlataforma);

            }

            var totalPeliculas = await consulta.CountAsync();
            var totalPages = (int)Math.Ceiling(totalPeliculas / (double)pageSize);
            page = totalPages == 0 ? 1 : Math.Min(page, totalPages);

            var Pelicula = await consulta
                .Include (p => p.Genero)
                 .OrderBy(p => p.Id)
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
               .ToListAsync();



            ViewBag.TxtBusqueda = txtBusqueda;
            ViewBag.IdGenero = IdGenero;
            ViewBag.IdPlataforma = IdPlataforma;
            var homeModel = new HomeViewModel
            {
                Genero = genero,
                Plataforma = Plataforma,
                Pelicula = Pelicula,
                PaginaActual = page,
                TotalPaginas = totalPages,
            };
            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
