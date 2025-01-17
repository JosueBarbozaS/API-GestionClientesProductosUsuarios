using ApiBigFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiBigFood.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DbContextBigFood contexto;

        public ClientesController(DbContextBigFood pContext)
        {
            this.contexto = pContext;
        }

        [HttpGet]
        public List<Cliente> Get()
        {
            return this.contexto.Clientes.ToList();
        }

        [HttpGet("{Cedula}")]
        public Cliente GetCliente(string Cedula)
        {
            return this.contexto.Clientes.Find(Cedula);
        }

        [HttpGet("cedula/{cedula}")]
        public List<Cliente> GetClientes(string cedula)
        {
            var clientes = this.contexto.Clientes.FromSqlRaw("EXECUTE Sp_Buscar_Clientes @Cedula",
            new SqlParameter("@Cedula", cedula)).ToList();

            return clientes;
        }

        [HttpPost("agregar")]
        public IActionResult Agregar(Cliente Cliente)
        {
            this.contexto.Add(Cliente);
            this.contexto.SaveChanges();

            return Ok();
        }

        [HttpDelete("{Cedula}")]
        public void Eliminar(string Cedula)
        {
            var temp = this.contexto.Clientes.Find(Cedula);
            if (temp != null)
            {
                this.contexto.Remove(temp);
                this.contexto.SaveChanges();
            }
        }

        [HttpPut("Modificar")]
        public void ModificarProducto(Cliente cliente)
        {
            this.contexto.Update(cliente);
            this.contexto.SaveChanges();
        }


    }
}

