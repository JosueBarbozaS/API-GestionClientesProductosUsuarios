using ApiBigFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiBigFood.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DbContextBigFood contexto;

        public ProductosController(DbContextBigFood pContext)
        {
            this.contexto = pContext;
        }


        [HttpGet]
        public List<Producto> Get()
        {
            return this.contexto.Productos.ToList();
        }

        [HttpGet("{CodigoInterno}")]
        public Producto GetProducto(int CodigoInterno)
        {
            return this.contexto.Productos.Find(CodigoInterno);
        }

        [HttpGet("descripcion/{Descripcion}")]
        public List<Producto> GetProductosPorDescripcion(string Descripcion)
        {
            var productos = this.contexto.Productos.FromSqlRaw("EXECUTE Sp_Buscar_Productos @Descripcion",
            new SqlParameter("@Descripcion", Descripcion)).ToList();

            return productos;
        }


        [HttpPost("agregar")]
        public IActionResult Agregar(Producto producto)
        {
            this.contexto.Add(producto);
            this.contexto.SaveChanges();

            return Ok();
        }

        [HttpDelete("{CodigoInterno}")]
        public void Eliminar(int CodigoInterno)
        {
            var temp = this.contexto.Productos.Find(CodigoInterno);
            if (temp != null)
            {
                this.contexto.Remove(temp);
                this.contexto.SaveChanges();
            }
        }

        [HttpPut("Modificar")]
        public void ModificarProducto(Producto producto)
        {
            this.contexto.Update(producto);
            this.contexto.SaveChanges();
        }

    }
}
