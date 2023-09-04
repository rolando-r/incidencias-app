namespace Dominio;
public class NivelIncidencia : BaseEntityA
{
    public string NombreNivelIncidencia { get; set; }
    public string DescripcionNivelIncidencia { get; set; }
    public ICollection<DetalleIncidencia> DetalleIncidencias { get; set; }
}