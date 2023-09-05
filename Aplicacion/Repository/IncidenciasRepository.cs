using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class IncidenciaRepository : GenericRepositoryB<Incidencia>, IIncidenciaRepository
    {
        public IncidenciaRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}