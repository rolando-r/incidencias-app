using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class TipoIncidenciaRepository : GenericRepositoryB<TipoIncidencia>, ITipoIncidenciaRepository
    {
        public TipoIncidenciaRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}