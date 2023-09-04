namespace Dominio;
public class Usuario
{
    public int IdUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public string ApellidoUsuario { get; set; }
    public string DireccionUsuario { get; set; }
    public int IdTipoDocumento { get; set; }
    public TipoDocumento  TipoDocumento { get; set; }
    public int IdRol { get; set; }
    public Rol  Rol { get; set; }
    public ICollection<Contacto> Contactos { get; set; }
    public ICollection<AreaUsuario> AreaUsuarios { get; set; }
    public ICollection<Incidencia> Incidencias { get; set; }
}