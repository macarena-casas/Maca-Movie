using maca_movie.Data;
using maca_movie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

     

        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 9;
            page = Math.Max(page, 1);

            var genero = await _context.Generos
               .ToListAsync();
            var Plataforma = await _context.Plataformas
               .ToListAsync();

            var totalPeliculas = await _context.Peliculas.CountAsync();
            var totalPages = (int)Math.Ceiling(totalPeliculas / (double)pageSize);
            page = totalPages == 0 ? 1 : Math.Min(page, totalPages);

            var Pelicula = await _context.Peliculas
                .Include (p => p.Genero)
                 .OrderBy(p => p.Id)
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
               .ToListAsync();


            var homeModel = new HomeViewModel
            {
                Genero = genero,
                Plataforma = Plataforma,
                Pelicula = Pelicula,
                PaginaActual = page,
                TotalPaginas = totalPages
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
