using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoContactoConfiguration : IEntityTypeConfiguration<TipoContacto>
{
    public void Configure(EntityTypeBuilder<TipoContacto> builder)
    {
        builder.ToTable("TipoContacto");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.DescripcionTipoContacto)
                .IsRequired()
                .HasMaxLength(200);
    }
}