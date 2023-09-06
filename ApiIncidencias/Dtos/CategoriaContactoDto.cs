namespace ApiIncidencias.Dtos;
public class CategoriaContactoDto
{
    public int Id { get; set; }
    public string NombreCategoriaContacto { get; set; }
    public ICollection<ContactoDto> Contactos { get; set; }
}