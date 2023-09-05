using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class UsuarioRepository : GenericRepositoryB<Usuario>, IUsuarioRepository
{
    private readonly IncidenciasContext _context;

    public UsuarioRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
        public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Usuarios
                            .Include(u=>u.Roles)
                            .FirstOrDefaultAsync(u=>u.Username.ToLower()==username.ToLower());
    }
}
