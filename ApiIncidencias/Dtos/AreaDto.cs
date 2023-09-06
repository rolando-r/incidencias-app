namespace ApiIncidencias.Dtos;
public class AreaDto
{
    public int Id { get; set;}
    public string NombreArea { get; set; }
    public string DescripcionArea { get; set; }
    public ICollection<IncidenciaDto> Incidencias { get; set; }
    public ICollection<LugarDto> Lugares { get; set; }
    public ICollection<PersonaDto> Personas { get; set; } = new HashSet<PersonaDto>();
}