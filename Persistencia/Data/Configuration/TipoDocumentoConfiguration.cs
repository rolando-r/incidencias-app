using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable("TipoDocumento");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.NombreTipoDocumento)
                .IsRequired()
                .HasMaxLength(200);

        builder.Property(p => p.AbreviaturaTipoDocumento)
        .IsRequired()
        .HasMaxLength(100);
    }
}