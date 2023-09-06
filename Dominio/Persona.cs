namespace Dominio
{
    public class Persona : BaseEntityA
    {
    public string NombrePersona { get; set; }
    public string ApellidoPersona { get; set; }
    public string DireccionPersona { get; set; }
    public int IdTipoDocumento { get; set; }
    public TipoDocumento  TipoDocumento { get; set; }
    //public int IdRol { get; set; }
    //public Rol  Rol { get; set; }
    public ICollection<Area> Areas { get; set; }
    public ICollection<Contacto> Contactos { get; set; }
    public ICollection<AreaPersona> AreaPersonas { get; set; }
    public ICollection<Incidencia> Incidencias { get; set; }
    }
}