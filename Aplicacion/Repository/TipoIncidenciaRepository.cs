using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class TipoIncidenciaRepository : GenericRepositoryB<TipoIncidencia>, ITipoIncidenciaRepository
{
    private readonly IncidenciasContext _context;
    public TipoIncidenciaRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}