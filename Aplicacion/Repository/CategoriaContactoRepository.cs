using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class CategoriaContactoRepository : GenericRepositoryB<CategoriaContacto>, ICategoriaContactoRepository
    {
        public CategoriaContactoRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}