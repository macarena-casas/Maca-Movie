using System.Reflection.Metadata.Ecma335;

namespace maca_movie.Models
{
    public class Favoritos
    {

        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula? Pelicula { get; set; }
        public DateTime Fecha { get; set; }

    }
}
