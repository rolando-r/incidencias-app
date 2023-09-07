using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class EstadoRepository : GenericRepositoryB<Estado>, IEstadoRepository
{
    private readonly IncidenciasContext _context;
    public EstadoRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}