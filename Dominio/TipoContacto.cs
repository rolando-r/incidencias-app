namespace Dominio;
    public class TipoContacto
    {
    public int IdTipoContacto { get; set; }
    public string DescripcionTipoContacto { get; set; }
     public ICollection<Contacto> Contactos  { get; set; }
    }
