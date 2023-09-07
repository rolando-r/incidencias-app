using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class DetalleIncidenciaRepository : GenericRepositoryB<DetalleIncidencia>, IDetalleIncidenciaRepository
    {
        public DetalleIncidenciaRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}