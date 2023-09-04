namespace Dominio;
public class Contacto : BaseEntityA
{
    public string DescripcionContacto { get; set; }
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
    public int IdTipoCon { get; set; }
    public TipoContacto TipoContacto { get; set; }
    public int IdCategoriaContacto { get; set; }
    public CategoriaContacto CategoriaContacto { get; set; }
}