using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class LugarRepository : GenericRepositoryB<Lugar>, ILugarRepository
    {
        public LugarRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}