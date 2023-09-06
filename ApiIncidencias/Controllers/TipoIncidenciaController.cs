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

// TipoIncidencia, tipoIncidencia, TipoIncidencias, tipoIncidencias

public class TipoIncidenciaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoIncidenciaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<TipoIncidencia>>> Get()
    {
        var regiones = await _unitOfWork.TipoIncidencias.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<TipoIncidenciaDto>>> Get()
    {
        var tipoIncidencias = await _unitOfWork.TipoIncidencias.GetAllAsync();
        return _mapper.Map<List<TipoIncidenciaDto>>(tipoIncidencias);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoIncidenciaDto>>> Get11([FromQuery] Params tipoIncidenciaParams)
    {
        var tipoIncidencia = await _unitOfWork.TipoIncidencias.GetAllAsync(tipoIncidenciaParams.PageIndex,tipoIncidenciaParams.PageSize,tipoIncidenciaParams.Search);
        var lstTipoIncidenciasDto = _mapper.Map<List<TipoIncidenciaDto>>(tipoIncidencia.registros);
        return new Pager<TipoIncidenciaDto>(lstTipoIncidenciasDto,tipoIncidencia.totalRegistros,tipoIncidenciaParams.PageIndex,tipoIncidenciaParams.PageSize,tipoIncidenciaParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoIncidenciaDto>> Get(int id)
    {
        var tipoIncidencia = await _unitOfWork.TipoIncidencias.GetByIdAsync(id);
        if (tipoIncidencia == null){
            return NotFound();
        }
        return _mapper.Map<TipoIncidenciaDto>(tipoIncidencia);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoIncidencia>> Post(TipoIncidencia tipoIncidencia){
        this._unitOfWork.TipoIncidencias.Add(tipoIncidencia);
        await _unitOfWork.SaveAsync();
        if (tipoIncidencia == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= tipoIncidencia.Id}, tipoIncidencia);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoIncidencia>> Post(TipoIncidenciaDto tipoIncidenciaDto){
        var tipoIncidencia = _mapper.Map<TipoIncidencia>(tipoIncidenciaDto);
        this._unitOfWork.TipoIncidencias.Add(tipoIncidencia);
        await _unitOfWork.SaveAsync();
        if (tipoIncidencia == null)
        {
            return BadRequest();
        }
        tipoIncidenciaDto.Id = tipoIncidencia.Id;
        return CreatedAtAction(nameof(Post),new {id= tipoIncidenciaDto.Id}, tipoIncidenciaDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area tipoIncidencia){
        if(tipoIncidencia == null)
            return NotFound();
        _unitOfWork.TipoIncidencias.Update(tipoIncidencia);
        await _unitOfWork.SaveAsync();
        return tipoIncidencia;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoIncidenciaDto>> Put(int id, [FromBody]TipoIncidenciaDto tipoIncidenciaDto){
        if(tipoIncidenciaDto == null)
            return NotFound();
        var tipoIncidencias = _mapper.Map<TipoIncidencia>(tipoIncidenciaDto);
        _unitOfWork.TipoIncidencias.Update(tipoIncidencias);
        await _unitOfWork.SaveAsync();
        return tipoIncidenciaDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var tipoIncidencia = await _unitOfWork.TipoIncidencias.GetByIdAsync(id);
        if(tipoIncidencia == null){
            return NotFound();
        }
        _unitOfWork.TipoIncidencias.Remove(tipoIncidencia);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}