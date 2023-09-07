using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class DetalleIncidenciaRepository : GenericRepositoryB<DetalleIncidencia>, IDetalleIncidenciaRepository
{
    private readonly IncidenciasContext _context;
    public DetalleIncidenciaRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}