using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class TipoDocumentoRepository : GenericRepositoryB<TipoDocumento>, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}