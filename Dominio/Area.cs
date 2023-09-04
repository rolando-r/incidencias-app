namespace Dominio;

public class Area : BaseEntityA
{
    public string NombreArea { get; set; }
    public string DescripcionArea { get; set; }
    public string DescripcionIncidencia { get; set; }
    public ICollection<Incidencia> Incidencias { get; set; }
    public ICollection<Lugar> Lugares { get; set; }
    public ICollection<AreaUsuario> AreaUsuarios { get; set; }
    public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
}