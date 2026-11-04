using System.ComponentModel.DataAnnotations;

namespace maca_movie.Models
{
    public class Plataforma
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public String Nombre { get; set; }
        [Url]
        public String Url { get; set; }
        [Url]
        public String LogoUrl { get; set; }
        public List<Pelicula>? PeliculasPlataforma{ get; set; }
    }
}
