namespace ApiIncidencias.Dtos;
public class ContactoDto
{
    public int Id { get; set; }
    public string DescripcionContacto { get; set; }
    public int IdPersona { get; set; }
    public PersonaDto Persona { get; set; }
    public int IdTipoCon { get; set; }
    public TipoContactoDto TipoContacto { get; set; }
    public int IdCategoriaContacto { get; set; }
    public CategoriaContactoDto CategoriaContacto { get; set; }
}