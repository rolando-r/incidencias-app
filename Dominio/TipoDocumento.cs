namespace Dominio;
public class TipoDocumento
{
    public int IdTipoDocumento { get; set; }
    public string NombreTipoDocumento { get; set; }
    public string AbreviaturaTipoDocumento { get; set; }
    public ICollection<Usuario> Usuarios { get; set; }
}