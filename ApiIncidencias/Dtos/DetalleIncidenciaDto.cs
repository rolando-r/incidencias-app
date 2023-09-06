namespace ApiIncidencias.Dtos;
public class DetalleIncidenciaDto
{
    public int Id { get; set; }
    public string NombreArea { get; set; }
    public string DescripcionDetalleIncidencia { get; set; }
    public int IdIncidencia { get; set; }
    public IncidenciaDto Incidencia { get; set; }
    public int IdPeriferico { get; set; }
    public PerifericoDto Periferico { get; set; }
}