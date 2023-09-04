using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.NombreUsuario)
                .IsRequired()
                .HasMaxLength(100);
        
        builder.Property(p => p.ApellidoUsuario)
                .IsRequired()
                .HasMaxLength(200);

        builder.Property(p => p.DireccionUsuario)
                .IsRequired()
                .HasMaxLength(200);

        builder.HasOne(y => y.TipoDocumento)
        .WithMany(l => l.Usuarios)
        .HasForeignKey(z => z.IdTipoDocumento)
        .IsRequired();

        builder.HasOne(y => y.Rol)
        .WithMany(l => l.Usuarios)
        .HasForeignKey(z => z.IdRol)
        .IsRequired();
    }
}