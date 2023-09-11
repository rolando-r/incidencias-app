namespace ApiIncidencias.Dtos;
public class DetalleIncidenciaDto
{
    public int Id { get; set; }
    public string NombreArea { get; set; }
    public string DescripcionDetalleIncidencia { get; set; }
    public int IdIncidencia { get; set; }
    public int IdPeriferico { get; set; }
}