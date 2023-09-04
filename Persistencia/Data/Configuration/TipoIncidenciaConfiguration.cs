using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoIncidenciaConfiguration : IEntityTypeConfiguration<TipoIncidencia>
{
    public void Configure(EntityTypeBuilder<TipoIncidencia> builder)
    {
        builder.ToTable("TipoIncidencia");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.NombreTipoIncidencia)
                .IsRequired()
                .HasMaxLength(200);

        builder.Property(p => p.DescripcionTipoIncidencia)
        .IsRequired()
        .HasMaxLength(200);
    }
}