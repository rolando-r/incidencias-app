using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class EstadoRepository : GenericRepositoryB<Estado>, IEstadoRepository
    {
        public EstadoRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}