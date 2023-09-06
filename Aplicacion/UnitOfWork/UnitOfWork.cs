using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;
namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IncidenciasContext context;
        private AreaRepository _areas;
        private CategoriaContactoRepository _categoriaContactos;
        private ContactoRepository _contactos;
        private DetalleIncidenciaRepository _detalleIncidencias;
        private EstadoRepository _estados;
        private IncidenciaRepository _incidencias;
        private LugarRepository _lugares;
        private NivelIncidenciaRepository _nivelIncidencias;
        private PerifericoRepository _perifericos;
        private RolRepository _roles;
        private TipoContactoRepository _tipoContactos;
        private TipoDocumentoRepository _tipoDocumentos;
        private TipoIncidenciaRepository _tipoIncidencias;
        private IUsuarioRepository _usuarios;
        private IPersonaRepository _personas; 
        public UnitOfWork(IncidenciasContext _context)
        {
            context = _context;
        }
        public IAreaRepository Areas
        {
            get
            {
                if (_areas == null)
                {
                    _areas = new AreaRepository(context);
                }
                return _areas;
            }
        }
        public ICategoriaContactoRepository CategoriaContactos
        {
            get
            {
                if (_categoriaContactos == null)
                {
                    _categoriaContactos = new CategoriaContactoRepository(context);
                }
                return _categoriaContactos;
            }
        }
        public IContactoRepository Contactos
        {
            get
            {
                if (_contactos == null)
                {
                    _contactos = new ContactoRepository(context);
                }
                return _contactos;
            }
        }
        public IDetalleIncidenciaRepository DetalleIncidencias
        {
            get
            {
                if (_detalleIncidencias == null)
                {
                    _detalleIncidencias = new DetalleIncidenciaRepository(context);
                }
                return _detalleIncidencias;
            }
        }
        public IEstadoRepository Estados
        {
            get
            {
                if (_estados == null)
                {
                    _estados = new EstadoRepository(context);
                }
                return _estados;
            }
        }
        public IIncidenciaRepository Incidencias
        {
            get
            {
                if (_incidencias == null)
                {
                    _incidencias = new IncidenciaRepository(context);
                }
                return _incidencias;
            }
        }
        public ILugarRepository Lugares
        {
            get
            {
                if (_lugares == null)
                {
                    _lugares = new LugarRepository(context);
                }
                return _lugares;
            }
        }
        public INivelIncidenciaRepository NivelIncidencias
        {
            get
            {
                if (_nivelIncidencias == null)
                {
                    _nivelIncidencias = new NivelIncidenciaRepository(context);
                }
                return _nivelIncidencias;
            }
        }
        public IPerifericoRepository Perifericos
        {
            get
            {
                if (_perifericos == null)
                {
                    _perifericos = new PerifericoRepository(context);
                }
                return _perifericos;
            }
        }
        public IRolRepository Rols
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(context);
                }
                return _roles;
            }
        }
        public ITipoContactoRepository TipoContactos
        {
            get
            {
                if (_tipoContactos == null)
                {
                    _tipoContactos = new TipoContactoRepository(context);
                }
                return _tipoContactos;
            }
        }
        public ITipoDocumentoRepository TipoDocumentos
        {
            get
            {
                if (_tipoDocumentos == null)
                {
                    _tipoDocumentos = new TipoDocumentoRepository(context);
                }
                return _tipoDocumentos;
            }
        }
        public ITipoIncidenciaRepository TipoIncidencias
        {
            get
            {
                if (_tipoIncidencias == null)
                {
                    _tipoIncidencias = new TipoIncidenciaRepository(context);
                }
                return _tipoIncidencias;
            }
        }
        public IRolRepository Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(context);
                }
                return _roles;
            }
        }
        public IPersonaRepository Personas
        {
            get
            {
                if (_personas == null)
                {
                    _personas = new PersonaRepository(context);
                }
                return _personas;
            }
        }
        public IUsuarioRepository Usuarios
        {
            get
            {
                if (_usuarios == null)
                {
                    _usuarios = new UsuarioRepository(context);
                }
                return _usuarios;
            }
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}