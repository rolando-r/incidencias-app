using ApiIncidencias.Dtos;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

// TipoContacto, tipoContacto, TipoContactos, tipoContactos

public class TipoContactoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoContactoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<TipoContacto>>> Get()
    {
        var regiones = await _unitOfWork.TipoContactos.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<TipoContactoDto>>> Get()
    {
        var tipoContactos = await _unitOfWork.TipoContactos.GetAllAsync();
        return _mapper.Map<List<TipoContactoDto>>(tipoContactos);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoContactoDto>>> Get11([FromQuery] Params tipoContactoParams)
    {
        var tipoContacto = await _unitOfWork.TipoContactos.GetAllAsync(tipoContactoParams.PageIndex,tipoContactoParams.PageSize,tipoContactoParams.Search);
        var lstTipoContactosDto = _mapper.Map<List<TipoContactoDto>>(tipoContacto.registros);
        return new Pager<TipoContactoDto>(lstTipoContactosDto,tipoContacto.totalRegistros,tipoContactoParams.PageIndex,tipoContactoParams.PageSize,tipoContactoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoContactoDto>> Get(int id)
    {
        var tipoContacto = await _unitOfWork.TipoContactos.GetByIdAsync(id);
        if (tipoContacto == null){
            return NotFound();
        }
        return _mapper.Map<TipoContactoDto>(tipoContacto);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoContacto>> Post(TipoContacto tipoContacto){
        this._unitOfWork.TipoContactos.Add(tipoContacto);
        await _unitOfWork.SaveAsync();
        if (tipoContacto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= tipoContacto.Id}, tipoContacto);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoContacto>> Post(TipoContactoDto tipoContactoDto){
        var tipoContacto = _mapper.Map<TipoContacto>(tipoContactoDto);
        this._unitOfWork.TipoContactos.Add(tipoContacto);
        await _unitOfWork.SaveAsync();
        if (tipoContacto == null)
        {
            return BadRequest();
        }
        tipoContactoDto.Id = tipoContacto.Id;
        return CreatedAtAction(nameof(Post),new {id= tipoContactoDto.Id}, tipoContactoDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area tipoContacto){
        if(tipoContacto == null)
            return NotFound();
        _unitOfWork.TipoContactos.Update(tipoContacto);
        await _unitOfWork.SaveAsync();
        return tipoContacto;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoContactoDto>> Put(int id, [FromBody]TipoContactoDto tipoContactoDto){
        if(tipoContactoDto == null)
            return NotFound();
        var tipoContactos = _mapper.Map<TipoContacto>(tipoContactoDto);
        _unitOfWork.TipoContactos.Update(tipoContactos);
        await _unitOfWork.SaveAsync();
        return tipoContactoDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var tipoContacto = await _unitOfWork.TipoContactos.GetByIdAsync(id);
        if(tipoContacto == null){
            return NotFound();
        }
        _unitOfWork.TipoContactos.Remove(tipoContacto);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}