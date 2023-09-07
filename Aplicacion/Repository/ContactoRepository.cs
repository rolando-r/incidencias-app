using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Application.Repository;
public class ContactoRepository : GenericRepositoryB<Contacto>, IContactoRepository
{
    private readonly IncidenciasContext _context;
    public ContactoRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
}