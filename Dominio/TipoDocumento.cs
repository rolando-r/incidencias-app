namespace Dominio;
public class TipoDocumento : BaseEntityA
{
    public string NombreTipoDocumento { get; set; }
    public string AbreviaturaTipoDocumento { get; set; }
    public ICollection<Persona> Personas { get; set; }
}