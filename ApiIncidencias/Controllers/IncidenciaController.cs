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

// Incidencia, incidencia, Incidencias, incidencias

public class IncidenciaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public IncidenciaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Incidencia>>> Get()
    {
        var regiones = await _unitOfWork.Incidencias.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<IncidenciaDto>>> Get()
    {
        var incidencias = await _unitOfWork.Incidencias.GetAllAsync();
        return _mapper.Map<List<IncidenciaDto>>(incidencias);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<IncidenciaDto>>> Get11([FromQuery] Params incidenciaParams)
    {
        var incidencia = await _unitOfWork.Incidencias.GetAllAsync(incidenciaParams.PageIndex,incidenciaParams.PageSize,incidenciaParams.Search);
        var lstIncidenciasDto = _mapper.Map<List<IncidenciaDto>>(incidencia.registros);
        return new Pager<IncidenciaDto>(lstIncidenciasDto,incidencia.totalRegistros,incidenciaParams.PageIndex,incidenciaParams.PageSize,incidenciaParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IncidenciaDto>> Get(int id)
    {
        var incidencia = await _unitOfWork.Incidencias.GetByIdAsync(id);
        if (incidencia == null){
            return NotFound();
        }
        return _mapper.Map<IncidenciaDto>(incidencia);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidencia>> Post(Incidencia incidencia){
        this._unitOfWork.Incidencias.Add(incidencia);
        await _unitOfWork.SaveAsync();
        if (incidencia == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= incidencia.Id}, incidencia);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidencia>> Post(IncidenciaDto incidenciaDto){
        var incidencia = _mapper.Map<Incidencia>(incidenciaDto);
        this._unitOfWork.Incidencias.Add(incidencia);
        await _unitOfWork.SaveAsync();
        if (incidencia == null)
        {
            return BadRequest();
        }
        incidenciaDto.Id = incidencia.Id;
        return CreatedAtAction(nameof(Post),new {id= incidenciaDto.Id}, incidenciaDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area incidencia){
        if(incidencia == null)
            return NotFound();
        _unitOfWork.Incidencias.Update(incidencia);
        await _unitOfWork.SaveAsync();
        return incidencia;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenciaDto>> Put(int id, [FromBody]IncidenciaDto incidenciaDto){
        if(incidenciaDto == null)
            return NotFound();
        var incidencias = _mapper.Map<Incidencia>(incidenciaDto);
        _unitOfWork.Incidencias.Update(incidencias);
        await _unitOfWork.SaveAsync();
        return incidenciaDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidencia = await _unitOfWork.Incidencias.GetByIdAsync(id);
        if(incidencia == null){
            return NotFound();
        }
        _unitOfWork.Incidencias.Remove(incidencia);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}