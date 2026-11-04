using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace maca_movie.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public String Nombre { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaLanzamiento { get; set; }
        [Required]
        [Range(1 , 500)]
        public int MinutosDuracion { get; set; }
        [Required]
        [StringLength(1000)]
        public String Sinopsis { get; set; }
        [Required]
        [Url]
        public String PosterUrl { get; set; }
        public int GeneroId { get; set; }
        public Genero? Genero { get; set; }
        public int PlataformaId { get; set; }
        public Plataforma? Plataforma { get; set; }
        [NotMapped]
        public int PromedioRating { get; set; }
        public List<Review>? Listareviews { get; set; }
        public List<Favoritos>? UsuariosFavoritos { get; set; }
    }
}
