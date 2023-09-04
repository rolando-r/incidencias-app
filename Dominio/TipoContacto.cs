namespace Dominio;
    public class TipoContacto : BaseEntityA
    {
    public string DescripcionTipoContacto { get; set; }
     public ICollection<Contacto> Contactos  { get; set; }
    }
