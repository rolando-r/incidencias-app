namespace Dominio;
public class AreaUsuario
{
    public int IdAreaUsuario { get; set; }
    public int IdArea { get; set; }
    public Area Area { get; set; }
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
}