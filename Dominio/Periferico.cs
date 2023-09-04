namespace Dominio;
public class Periferico : BaseEntityA
{
    public string NombrePeriferico { get; set; }
    public ICollection<DetalleIncidencia> DetalleIncidencias  { get; set; }
}