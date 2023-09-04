using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DetalleIncidenciaConfiguration : IEntityTypeConfiguration<DetalleIncidencia>
{
    public void Configure(EntityTypeBuilder<DetalleIncidencia> builder)
    {
        builder.ToTable("DetalleIncidencia");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.DescripcionDetalleIncidencia)
                .IsRequired()
                .HasMaxLength(200);

        builder.HasOne(y => y.Incidencia)
        .WithMany(l => l.DetalleIncidencias)
        .HasForeignKey(z => z.IdIncidencia)
        .IsRequired();

        builder.HasOne(y => y.Periferico)
        .WithMany(l => l.DetalleIncidencias)
        .HasForeignKey(z => z.IdPeriferico)
        .IsRequired();

        builder.HasOne(y => y.TipoIncidencia)
        .WithMany(l => l.DetalleIncidencias)
        .HasForeignKey(z => z.IdTipoIncidencia)
        .IsRequired();

        builder.HasOne(y => y.NivelIncidencia)
        .WithMany(l => l.DetalleIncidencias)
        .HasForeignKey(z => z.IdNivelIncidencia)
        .IsRequired();

        builder.HasOne(y => y.Estado)
        .WithMany(l => l.DetalleIncidencias)
        .HasForeignKey(z => z.IdEstado)
        .IsRequired();
    }
}