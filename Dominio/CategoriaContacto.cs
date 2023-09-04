namespace Dominio;
public class CategoriaContacto : BaseEntityA
{
    public string NombreCategoriaContacto { get; set; }
    public ICollection<Contacto> Contactos { get; set; }
}