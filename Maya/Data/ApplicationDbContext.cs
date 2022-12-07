using Maya.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Maya.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options)
        {

        }

      
        public DbSet<Categoria> Categoria { get; set; } 
        public DbSet<TipoAplicacion> TipoAplicacion { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<UsuarioAplicacion> UsuarioAplicacion { get; set; }
    }
}
