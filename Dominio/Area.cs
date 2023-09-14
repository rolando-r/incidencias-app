namespace Dominio;

public class Area : BaseEntityA
{
    public string NombreArea { get; set; }
    public string DescripcionArea { get; set; }
    public ICollection<DetalleIncidencia> DetalleIncidencias { get; set; }
    public ICollection<Incidencia> Incidencias { get; set; }
    public ICollection<Lugar> Lugares { get; set; }
    public ICollection<AreaPersona> AreaPersonas { get; set; }
    public ICollection<Persona> Personas { get; set; } = new HashSet<Persona>();
}