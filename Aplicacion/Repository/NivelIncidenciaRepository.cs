using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class NivelIncidenciaRepository : GenericRepositoryB<NivelIncidencia>, INivelIncidenciaRepository
    {
        public NivelIncidenciaRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}