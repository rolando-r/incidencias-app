using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class LugarConfiguration : IEntityTypeConfiguration<Lugar>
{
    public void Configure(EntityTypeBuilder<Lugar> builder)
    {
        builder.ToTable("Lugar");
        builder.Property(p => p.Id)
                .IsRequired();

        builder.Property(p => p.NombreLugar)
                .IsRequired()
                .HasMaxLength(100);
                
        builder.Property(p => p.DescripcionLugar)
                .IsRequired()
                .HasMaxLength(200);
    }
}