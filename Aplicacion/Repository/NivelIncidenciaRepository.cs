using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class NivelIncidenciaRepository : GenericRepositoryB<NivelIncidencia>, INivelIncidenciaRepository
{
    private readonly IncidenciasContext _context;
    public NivelIncidenciaRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}