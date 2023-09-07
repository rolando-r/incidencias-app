using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class TipoContactoRepository : GenericRepositoryB<TipoContacto>, ITipoContactoRepository
{
    private readonly IncidenciasContext _context;
    public TipoContactoRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}