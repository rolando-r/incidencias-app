using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Persona");
            builder.Property(p => p.Id)
                    .IsRequired();
                    
            builder.Property(p => p.NombrePersona)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.ApellidoPersona)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.DireccionPersona)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.HasOne(y => y.TipoDocumento)
            .WithMany(l => l.Personas)
            .HasForeignKey(z => z.IdTipoDocumento)
            .IsRequired();
        }
    }
}