using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class TipoDocumentoRepository : GenericRepositoryB<TipoDocumento>, ITipoDocumentoRepository
{
    private readonly IncidenciasContext _context;
    public TipoDocumentoRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}