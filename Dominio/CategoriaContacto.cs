namespace Dominio;
public class CategoriaContacto
{
    public int IdCategoriaContacto { get; set; }
    public string NombreCategoriaContacto { get; set; }
    public ICollection<Contacto> Contactos { get; set; }
}