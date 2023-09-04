namespace Dominio;
public class Rol
{
    public int IdRol { get; set; }
    public string NombreRol { get; set; }
    public string DescripcionRol { get; set; }
    public ICollection<Usuario> Usuarios { get; set; }
}