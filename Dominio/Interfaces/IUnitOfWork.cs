namespace Dominio.Interfaces;
public interface IUnitOfWork
{
    IAreaRepository Areas { get; }

    /* IAreaUsuarioRepository AreaUsuarios { get; } */

    ICategoriaContactoRepository CategoriaContactos { get; }
    IContactoRepository Contactos { get; }
    IDetalleIncidenciaRepository DetalleIncidencias { get; }
    IEstadoRepository Estados { get; }
    IIncidenciaRepository Incidencias { get; }
    ILugarRepository Lugares { get; }
    INivelIncidenciaRepository NivelIncidencias { get; }
    IPerifericoRepository Perifericos { get; }
    ITipoContactoRepository TipoContactos { get; }
    ITipoDocumentoRepository TipoDocumentos { get; }
    ITipoIncidenciaRepository TipoIncidencias { get; }
    IRolRepository Roles { get; }
    IUsuarioRepository Usuarios { get; }
    IPersonaRepository Personas { get; }
    Task<int> SaveAsync();
}