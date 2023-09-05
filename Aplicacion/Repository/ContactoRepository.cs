using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class ContactoRepository : GenericRepositoryB<Contacto>, IContactoRepository
    {
        public ContactoRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}