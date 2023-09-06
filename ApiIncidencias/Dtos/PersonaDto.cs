namespace ApiIncidencias.Dtos;
public class PersonaDto
{
    public int Id { get; set; }
    public string NombrePersona { get; set; }
    public string ApellidoPersona { get; set; }
    public string DireccionPersona { get; set; }
    public int IdTipoDocumento { get; set; }
    public TipoDocumentoDto  TipoDocumento { get; set; }
    public ICollection<ContactoDto> Contactos { get; set; }
}