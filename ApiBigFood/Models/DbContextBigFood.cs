using Microsoft.EntityFrameworkCore;

namespace ApiBigFood.Models
{
    public class DbContextBigFood : DbContext
    {
        public DbContextBigFood(DbContextOptions<DbContextBigFood> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { set; get; }

        public DbSet<Cliente> Clientes { set; get; }

        public DbSet<Usuario> Usuarios { set; get; }
    }
}
