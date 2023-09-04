namespace Dominio;
public class TipoIncidencia
{
    public int IdTipoIncidencia { get; set; }
    public string NombreTipoIncidencia { get; set; }
    public string DescripcionTipoIncidencia { get; set; }
    public ICollection<DetalleIncidencia> DetalleIncidencias { get; set; }
}