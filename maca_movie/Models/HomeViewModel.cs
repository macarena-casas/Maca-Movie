namespace maca_movie.Models
{
    public class HomeViewModel
    {
        public  List<Genero> Genero { get; set; }
        public  List<Plataforma> Plataforma { get; set; }
        public  List<Pelicula> Pelicula { get; set; }
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
    }
}
