using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class PersonaRepository : GenericRepositoryB<Persona>, IPersonaRepository
{
    private readonly IncidenciasContext _context;
    public PersonaRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}