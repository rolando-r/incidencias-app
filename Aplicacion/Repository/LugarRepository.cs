using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class LugarRepository : GenericRepositoryB<Lugar>, ILugarRepository
{
    private readonly IncidenciasContext _context;
    public LugarRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}