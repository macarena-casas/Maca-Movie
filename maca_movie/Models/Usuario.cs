using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace maca_movie.Models
{
    public class Usuario: IdentityUser
    {

        [Required]
        [StringLength(50)]
        public String Nombre { get; set; }
        [Required]
        [StringLength(50)] 
        public String Apellido { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public String ImagenUrlPerfil { get; set; }
        public List <Favoritos>? PeliculasFavoritas { get; set; }
        public List <Review>? ReviewsUsuarios { get; set; }
    }
}
