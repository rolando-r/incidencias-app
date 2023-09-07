using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class PersonaRepository : GenericRepositoryB<Persona>, IPersonaRepository
    {
        public PersonaRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}