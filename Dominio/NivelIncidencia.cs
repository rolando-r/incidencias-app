namespace Dominio;
public class NivelIncidencia
{
    public int IdNivelIncidencia { get; set; }
    public string NombreNivelIncidencia { get; set; }
    public string DescripcionNivelIncidencia { get; set; }
    public ICollection<DetalleIncidencia> DetalleIncidencias { get; set; }
}