namespace Dominio;
public class TipoIncidencia : BaseEntityA
{
    public string NombreTipoIncidencia { get; set; }
    public string DescripcionTipoIncidencia { get; set; }
    public ICollection<DetalleIncidencia> DetalleIncidencias { get; set; }
}