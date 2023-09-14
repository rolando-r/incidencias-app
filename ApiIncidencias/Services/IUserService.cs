using API.Dtos;
using ApiIncidencias.Dtos;

namespace ApiIncidencias.Services;

public interface IUserService
{
    Task<string> RegisterAsync(RegisterDto model);
    Task<DatosUsuarioDto> GetTokenAsync(LoginDto model);
    Task<DatosUsuarioDto> GetTokenAsync(AuthenticationTokenResultDto model);
    Task<string> AddRoleAsync(AddRoleDto model);
}