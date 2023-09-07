using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class IncidenciaRepository : GenericRepositoryB<Incidencia>, IIncidenciaRepository
{
    private readonly IncidenciasContext _context;
    public IncidenciaRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}