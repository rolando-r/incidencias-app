namespace Dominio;
public class Estado
{
    public int IdEstado { get; set; }
    public string DescripcionEstado { get; set; }
    public ICollection<DetalleIncidencia> DetalleIncidencias { get; set; }
    public ICollection<Incidencia> Incidencias { get; set; }
    
}