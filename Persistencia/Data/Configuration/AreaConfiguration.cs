using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.ToTable("Area");
        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(p => p.NombreArea)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.DescripcionArea)
        .IsRequired()
        .HasMaxLength(100);

        builder
            .HasMany(p => p.Usuarios)
            .WithMany(p => p.Areas)
            .UsingEntity<AreaUsuario>(
                j => j
                    .HasOne(pt => pt.Usuario)
                    .WithMany(t => t.AreaUsuarios)
                    .HasForeignKey(pt => pt.IdUsuario),
                j => j
                    .HasOne(pt => pt.Area)
                    .WithMany(p => p.AreaUsuarios)
                    .HasForeignKey(pt => pt.IdArea),
                j =>
                {
                    j.HasKey(t => new { t.IdArea, t.IdUsuario });
                });
    }
}