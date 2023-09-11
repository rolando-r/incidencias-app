using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class AreaRepository : GenericRepositoryB<Area>, IAreaRepository
    {
        public AreaRepository(IncidenciasContext context) : base(context)
        {
        }
        /* public override async Task<IEnumerable<Area>> GetAllAsync()
        {
            return await _context.Areas
            .Include(p => p.Lugares)
            .ToListAsync();
        } */

        public override async Task<Area> GetByIdAsync(int id)
        {
            return await _context.Areas
            .Include(p => p.Lugares)
            .FirstOrDefaultAsync(x => x.Id == id);
        } 

        public override async Task<(int totalRegistros, IEnumerable<Area> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Areas as IQueryable<Area>;
        if(!string.IsNullOrEmpty(search)) query=query.Where(p=>p.NombreArea.ToLower().Contains(search));
        var totalRegistros=await query.CountAsync();
        var registros = await query
            .Include(p=>p.Lugares)
            .Skip((pageIndex-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros,registros);
    }
    }
}