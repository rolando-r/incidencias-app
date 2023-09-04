using System.Reflection;
using Dominio;
using Microsoft.EntityFrameworkCore;
namespace Persistencia
{
    public class IncidenciasContext : DbContext
    {
        public IncidenciasContext(DbContextOptions<IncidenciasContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoIncidencia> TipoIncidencias { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Lugar> Lugares { get; set; }
        public DbSet<Periferico> Perifericos { get; set; }
        public DbSet<NivelIncidencia> NivelIncidencias { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<DetalleIncidencia> DetalleIncidencias { get; set; }
        public DbSet<TipoContacto> TipoContactos { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<CategoriaContacto> CategoriaContactos { get; set; }
        public DbSet<AreaUsuario> AreaUsuarios { get; set; }
        public DbSet<Area> Areas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

        