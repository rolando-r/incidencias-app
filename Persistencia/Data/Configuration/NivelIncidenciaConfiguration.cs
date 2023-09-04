using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class NivelIncidenciaConfiguration : IEntityTypeConfiguration<NivelIncidencia>
{
    public void Configure(EntityTypeBuilder<NivelIncidencia> builder)
    {
        builder.ToTable("NivelIncidencia");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.NombreNivelIncidencia)
                .IsRequired()
                .HasMaxLength(200);

        builder.Property(p => p.DescripcionNivelIncidencia)
                .IsRequired()
                .HasMaxLength(200);
    }
}