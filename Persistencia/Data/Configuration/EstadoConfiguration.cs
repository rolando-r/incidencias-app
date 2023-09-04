using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estado");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.DescripcionEstado)
                .IsRequired()
                .HasMaxLength(200);
    }
}