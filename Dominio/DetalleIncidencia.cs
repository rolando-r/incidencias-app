namespace Dominio;
public class DetalleIncidencia : BaseEntityA
{
    public string DescripcionDetalleIncidencia { get; set; }
    public int IdIncidencia { get; set; }
    public Incidencia Incidencia { get; set; }
    public int IdPeriferico { get; set; }
    public Periferico Periferico { get; set; }
    public int IdTipoIncidencia { get; set; }
    public TipoIncidencia TipoIncidencia { get; set; }
    public int IdNivelIncidencia { get; set; }
    public NivelIncidencia NivelIncidencia { get; set; }
    public int IdEstado { get; set; }
    public Estado Estado { get; set; }
}