namespace ApiIncidencias.Dtos;
public class ContactoDto
{
    public int Id { get; set; }
    public string DescripcionContacto { get; set; }
    public int IdPersona { get; set; }
    public int IdTipoCon { get; set; }
    public int IdCategoriaContacto { get; set; }
}