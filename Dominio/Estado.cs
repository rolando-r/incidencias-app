namespace Dominio;
public class Estado : BaseEntityA
{
    public string DescripcionEstado { get; set; }
    public ICollection<DetalleIncidencia> DetalleIncidencias { get; set; }
    public ICollection<Incidencia> Incidencias { get; set; }
}