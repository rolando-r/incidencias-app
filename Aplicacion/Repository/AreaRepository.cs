using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class AreaRepository : GenericRepositoryB<Area>, IAreaRepository
{
    private readonly IncidenciasContext _context;
    public AreaRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}