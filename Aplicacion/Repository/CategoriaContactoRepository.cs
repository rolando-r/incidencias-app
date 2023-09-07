using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class CategoriaContactoRepository : GenericRepositoryB<CategoriaContacto>, ICategoriaContactoRepository
{
    private readonly IncidenciasContext _context;
    public CategoriaContactoRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}