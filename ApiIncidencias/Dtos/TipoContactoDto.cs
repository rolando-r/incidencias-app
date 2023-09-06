namespace ApiIncidencias.Dtos;
public class TipoContactoDto
{
    public int Id { get; set; }
    public string NombreArea { get; set; }
    public ICollection<ContactoDto> Contactos  { get; set; }
}