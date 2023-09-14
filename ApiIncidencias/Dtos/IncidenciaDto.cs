namespace ApiIncidencias.Dtos;
public class IncidenciaDto
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string DescripcionIncidencia { get; set; }
    public int IdEstado { get; set; }
    public ICollection<DetalleIncidenciaDto> DetalleIncidencias  { get; set; }
}