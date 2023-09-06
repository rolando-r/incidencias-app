namespace ApiIncidencias.Dtos;
public class TipoDocumentoDto
{
    public int Id { get; set; }
    public string NombreTipoDocumento { get; set; }
    public string AbreviaturaTipoDocumento { get; set; }
    public ICollection<PersonaDto> Personas { get; set; }
}