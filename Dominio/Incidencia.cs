namespace Dominio;
public class Incidencia
{
    public int IdIncidencia { get; set; }
    public DateTime Fecha { get; set; }
    public string DescripcionIncidencia { get; set; }
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
    public int IdEstado { get; set; }
    public Estado Estado { get; set; }
    public int IdArea { get; set; }
     public Area Area { get; set; }
    public int IdLugar { get; set; }
    public Lugar Lugar { get; set; }
    public ICollection<DetalleIncidencia> DetalleIncidencias  { get; set; }
}