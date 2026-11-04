using System.ComponentModel.DataAnnotations;

namespace maca_movie.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula? Pelicula { get; set; }
        public string UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        [Range (1 , 5)]
        public int Rating { get; set; }
        [Required]
        [StringLength(500)]
        public String Comentario { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaReview { get; set; }
        //row version for concurrency control
        [Timestamp]
        public byte[]RowVersion { get; set; }
    }
}
