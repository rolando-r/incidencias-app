namespace Dominio;
public class Rol : BaseEntityA
{
    public string NombreRol { get; set; }
    public string DescripcionRol { get; set; }
    public ICollection<Usuario> Usuarios { get; set; }
}