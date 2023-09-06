namespace ApiIncidencias.Dtos;
public class AreaxLugarDto
{
    public int Id { get; set; }
    public string NombreArea { get; set; }
    public List<LugarDto> Lugares { get; set; }
}