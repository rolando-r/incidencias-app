using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class PerifericoRepository : GenericRepositoryB<Periferico>, IPerifericoRepository
{
    private readonly IncidenciasContext _context;
    public PerifericoRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}