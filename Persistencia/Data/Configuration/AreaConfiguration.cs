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
            .HasMany(p => p.Personas)
            .WithMany(p => p.Areas)
            .UsingEntity<AreaPersona>(
                j => j
                    .HasOne(pt => pt.Persona)
                    .WithMany(t => t.AreaPersonas)
                    .HasForeignKey(pt => pt.IdPersona),
                j => j
                    .HasOne(pt => pt.Area)
                    .WithMany(p => p.AreaPersonas)
                    .HasForeignKey(pt => pt.IdArea),
                j =>
                {
                    j.HasKey(t => new { t.IdArea, t.IdPersona });
                });
    }
}