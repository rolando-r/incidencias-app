using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class IncidenciaRepository : GenericRepositoryB<Incidencia>, IIncidenciaRepository
    {
        public IncidenciaRepository(IncidenciasContext context) : base(context)
        {
        }
        /* public override async Task<IEnumerable<Area>> GetAllAsync()
        {
            return await _context.Incidencias
            .Include(p => p.DetalleIncidencias)
            .ToListAsync();
        } */
        public override async Task<Incidencia> GetByIdAsync(int id)
        {
            return await _context.Incidencias
            .Include(p => p.DetalleIncidencias)
            .FirstOrDefaultAsync(x => x.Id == id);
        } 

        public override async Task<(int totalRegistros, IEnumerable<Incidencia> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Incidencias as IQueryable<Incidencia>;
        if(!string.IsNullOrEmpty(search)) query=query.Where(p=>p.DescripcionIncidencia.ToLower().Contains(search));
        var totalRegistros=await query.CountAsync();
        var registros = await query
            .Include(p=>p.DetalleIncidencias)
            .Skip((pageIndex-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros,registros);
    }
    }
}