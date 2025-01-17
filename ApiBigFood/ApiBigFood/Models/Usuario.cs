using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiBigFood.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        
        public string Login { get; set; }

      
        public string Password { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        public char Estado { get; set; } = 'A';

  
    }
}
