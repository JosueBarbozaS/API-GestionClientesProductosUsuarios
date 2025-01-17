using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiBigFood.Models
{
    public class Producto
    {
        [Key]
        public int CodigoInterno { get; set; }

        
        public string CodigoBarra { get; set; }

        
        public string Descripcion { get; set; }

        
        public decimal PrecioVenta { get; set; }

        
        public int Descuento { get; set; }

        
        public int Impuesto { get; set; }

       
        public string UnidadMedida { get; set; }

        public decimal PrecioCompra { get; set; }

        
        public string Usuario { get; set; }

        
        public int Existencia { get; set; }
    }
}
