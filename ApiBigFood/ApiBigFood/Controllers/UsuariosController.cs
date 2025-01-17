using ApiBigFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBigFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DbContextBigFood dbContext;


        /// <summary>
        /// Constructor por omision para manejar la referencia del dbcontext
        /// </summary>
        /// <param name="dbContext"></param>
        public UsuariosController(DbContextBigFood dbContext)
        {
            this.dbContext = dbContext;
        }

        //-----------------------------------------------------------------------------

        //Metodo encargado de retornar una lista de todos los usuarios

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return this.dbContext.Usuarios.ToList();
        }
        //-----------------------------------------------------------------------------

        //Metodo encargado de buscar un usuario especifico

        [HttpGet("Buscar/{Login}")]
        public IActionResult Get(string Login)
        {
            try
            {
                var temp = this.dbContext.Usuarios.FirstOrDefault(u => u.Login.Equals(Login));

                return StatusCode(StatusCodes.Status200OK, temp);

            }
            catch (Exception ex)
            {
                return NotFound("Error" + ex.Message);
            }
        }

        //llamar a un procedimiento
        [HttpGet("AutenticarUsuario/{Login},{Password}")]
        public Usuario AutenticarUsuario(string Login, string Password)
        {

            try
            {
                var temp = this.dbContext.Usuarios.FirstOrDefault(u => u.Login.Equals(Login));

                if (temp != null)
                {

                    if (temp.Password.Equals(Password))
                    {
                        return temp;
                    }

                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //-----------------------------------------------------------------------------

        //Metodo encargado de agregar un usuario

        [HttpPost("Agregar")]
        public IActionResult Post([FromBody] Usuario value)
        {
            //recibe un objeto especifico
            try
            {
                this.dbContext.Usuarios.Add(value);
                this.dbContext.SaveChanges();
                return Ok("** Usuario almacenado correctamente **");
            }
            catch (Exception ex)
            {
                return NotFound("Error" + ex.Message);
            }
        }

        //-----------------------------------------------------------------------------

        // PUT api/<UsuariosController>/5
        [HttpPut("Editar/{Login}")]
        public IActionResult Edit([FromBody] Usuario usuarios, String Login)
        {
            try
            {
                var temp = this.dbContext.Usuarios.FirstOrDefault(u => u.Login.Equals(Login));

                if (temp != null)
                {
                    //Se actualizan los datos
                    temp.Password = usuarios.Password;
                    temp.Estado = usuarios.Estado;
                    this.dbContext.Usuarios.Update(temp);
                    this.dbContext.SaveChanges();
                }

                return Ok("** El usuario ha sido editado correctamente **");
            }
            catch (Exception ex)
            {

                return NotFound("Error " + ex.Message);
            }
        }


        //-----------------------------------------------------------------------------

        //Metodo encargado de colocar inactivo


        [HttpGet("Inactivar/{Login}")]
        public IActionResult Inactividad(string Login)
        {
            try
            {
                var temp = dbContext.Usuarios.FirstOrDefault(c => c.Login == Login);

                if (temp != null)
                {
                    temp.Estado = 'I';

                    dbContext.SaveChanges();

                    return Ok("** El usuario ha sido marcado como inactivo **");
                }
                else
                {
                    return NotFound("No se encontró el usuario con la cédula legal especificada.");
                }
            }
            catch (Exception ex)
            {

                return NotFound("Error " + ex.Message);
            }
        }

        //-----------------------------------------------------------------------------
    }
}
