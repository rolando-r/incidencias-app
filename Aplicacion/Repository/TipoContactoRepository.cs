using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class TipoContactoRepository : GenericRepositoryB<TipoContacto>, ITipoContactoRepository
    {
        public TipoContactoRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}