namespace ApiIncidencias.Dtos;
public class EstadoDto
{
    public int Id { get; set; }
    public string DescripcionEstado { get; set; }
    public ICollection<IncidenciaDto> Incidencias { get; set; }
}