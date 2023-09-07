using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class RolRepository : GenericRepositoryB<Rol>, IRolRepository
{
    private readonly IncidenciasContext _context;
    public RolRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}