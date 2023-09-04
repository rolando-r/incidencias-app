namespace Dominio;
public class Lugar: BaseEntityA
{
    public string NombreLugar { get; set; }
    public string DescripcionLugar { get; set; }
    public ICollection<Incidencia> Incidencias { get; set; }
}