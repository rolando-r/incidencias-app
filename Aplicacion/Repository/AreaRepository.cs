using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class AreaRepository : GenericRepositoryB<Area>, IAreaRepository
    {
        public AreaRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}