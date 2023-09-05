using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class PerifericoRepository : GenericRepositoryB<Periferico>, IPerifericoRepository
    {
        public PerifericoRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}