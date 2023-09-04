namespace Dominio;
public class Lugar
{
    public int IdLugar { get; set; }
    public string DescripcionLugar { get; set; }
    public ICollection<Incidencia> Incidencias { get; set; }
}