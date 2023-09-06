namespace Dominio;
public class Incidencia : BaseEntityA
{
    public DateTime Fecha { get; set; }
    public string DescripcionIncidencia { get; set; }
    public int IdPersona { get; set; }
    public Persona Persona { get; set; }
    public int IdEstado { get; set; }
    public Estado Estado { get; set; }
    public int IdArea { get; set; }
     public Area Area { get; set; }
    public int IdLugar { get; set; }
    public Lugar Lugar { get; set; }
    public ICollection<DetalleIncidencia> DetalleIncidencias  { get; set; }
}