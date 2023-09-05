namespace Dominio;
public class Usuario : BaseEntityA
{
    public string Username { get; set; }
    public string ApellidoUsuario { get; set; }
    public string DireccionUsuario { get; set; }
    public int IdTipoDocumento { get; set; }
    public TipoDocumento  TipoDocumento { get; set; }
    public int IdRol { get; set; }
    public Rol  Rol { get; set; }
    public ICollection<Area> Areas { get; set; }
    public ICollection<Contacto> Contactos { get; set; }
    public ICollection<AreaUsuario> AreaUsuarios { get; set; }
    public ICollection<Incidencia> Incidencias { get; set; }
    public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
    public ICollection<UsuariosRoles> UsuariosRoles { get; set; }
}