using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiBigFood.Models
{
    public class Cliente
    {
        [Key]
        public string CedulaLegal { get; set; }

 
        public string TipoCedula { get; set; }

        
        public string NombreCompleto { get; set; }

       
        
        public string Email { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        
        public char Estado { get; set; } = 'A';

        public string Usuario { get; set; }

       
    }
}
