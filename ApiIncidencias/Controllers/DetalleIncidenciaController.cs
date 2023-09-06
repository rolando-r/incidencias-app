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

// DetalleIncidencia, detalleIncidencia, DetalleIncidencias, detalleIncidencias

public class DetalleIncidenciaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DetalleIncidenciaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<DetalleIncidencia>>> Get()
    {
        var regiones = await _unitOfWork.DetalleIncidencias.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<DetalleIncidenciaDto>>> Get()
    {
        var detalleIncidencias = await _unitOfWork.DetalleIncidencias.GetAllAsync();
        return _mapper.Map<List<DetalleIncidenciaDto>>(detalleIncidencias);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetalleIncidenciaDto>>> Get11([FromQuery] Params detalleIncidenciaParams)
    {
        var detalleIncidencia = await _unitOfWork.DetalleIncidencias.GetAllAsync(detalleIncidenciaParams.PageIndex,detalleIncidenciaParams.PageSize,detalleIncidenciaParams.Search);
        var lstDetalleIncidenciasDto = _mapper.Map<List<DetalleIncidenciaDto>>(detalleIncidencia.registros);
        return new Pager<DetalleIncidenciaDto>(lstDetalleIncidenciasDto,detalleIncidencia.totalRegistros,detalleIncidenciaParams.PageIndex,detalleIncidenciaParams.PageSize,detalleIncidenciaParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleIncidenciaDto>> Get(int id)
    {
        var detalleIncidencia = await _unitOfWork.DetalleIncidencias.GetByIdAsync(id);
        if (detalleIncidencia == null){
            return NotFound();
        }
        return _mapper.Map<DetalleIncidenciaDto>(detalleIncidencia);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleIncidencia>> Post(DetalleIncidencia detalleIncidencia){
        this._unitOfWork.DetalleIncidencias.Add(detalleIncidencia);
        await _unitOfWork.SaveAsync();
        if (detalleIncidencia == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= detalleIncidencia.Id}, detalleIncidencia);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleIncidencia>> Post(DetalleIncidenciaDto detalleIncidenciaDto){
        var detalleIncidencia = _mapper.Map<DetalleIncidencia>(detalleIncidenciaDto);
        this._unitOfWork.DetalleIncidencias.Add(detalleIncidencia);
        await _unitOfWork.SaveAsync();
        if (detalleIncidencia == null)
        {
            return BadRequest();
        }
        detalleIncidenciaDto.Id = detalleIncidencia.Id;
        return CreatedAtAction(nameof(Post),new {id= detalleIncidenciaDto.Id}, detalleIncidenciaDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area detalleIncidencia){
        if(detalleIncidencia == null)
            return NotFound();
        _unitOfWork.DetalleIncidencias.Update(detalleIncidencia);
        await _unitOfWork.SaveAsync();
        return detalleIncidencia;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleIncidenciaDto>> Put(int id, [FromBody]DetalleIncidenciaDto detalleIncidenciaDto){
        if(detalleIncidenciaDto == null)
            return NotFound();
        var detalleIncidencias = _mapper.Map<DetalleIncidencia>(detalleIncidenciaDto);
        _unitOfWork.DetalleIncidencias.Update(detalleIncidencias);
        await _unitOfWork.SaveAsync();
        return detalleIncidenciaDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var detalleIncidencia = await _unitOfWork.DetalleIncidencias.GetByIdAsync(id);
        if(detalleIncidencia == null){
            return NotFound();
        }
        _unitOfWork.DetalleIncidencias.Remove(detalleIncidencia);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}