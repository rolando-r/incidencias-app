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

// NivelIncidencia, nivelIncidencia, NivelIncidencias, nivelIncidencias

public class NivelIncidenciaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NivelIncidenciaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<NivelIncidencia>>> Get()
    {
        var regiones = await _unitOfWork.NivelIncidencias.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<NivelIncidenciaDto>>> Get()
    {
        var nivelIncidencias = await _unitOfWork.NivelIncidencias.GetAllAsync();
        return _mapper.Map<List<NivelIncidenciaDto>>(nivelIncidencias);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<NivelIncidenciaDto>>> Get11([FromQuery] Params nivelIncidenciaParams)
    {
        var nivelIncidencia = await _unitOfWork.NivelIncidencias.GetAllAsync(nivelIncidenciaParams.PageIndex,nivelIncidenciaParams.PageSize,nivelIncidenciaParams.Search);
        var lstNivelIncidenciasDto = _mapper.Map<List<NivelIncidenciaDto>>(nivelIncidencia.registros);
        return new Pager<NivelIncidenciaDto>(lstNivelIncidenciasDto,nivelIncidencia.totalRegistros,nivelIncidenciaParams.PageIndex,nivelIncidenciaParams.PageSize,nivelIncidenciaParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<NivelIncidenciaDto>> Get(int id)
    {
        var nivelIncidencia = await _unitOfWork.NivelIncidencias.GetByIdAsync(id);
        if (nivelIncidencia == null){
            return NotFound();
        }
        return _mapper.Map<NivelIncidenciaDto>(nivelIncidencia);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NivelIncidencia>> Post(NivelIncidencia nivelIncidencia){
        this._unitOfWork.NivelIncidencias.Add(nivelIncidencia);
        await _unitOfWork.SaveAsync();
        if (nivelIncidencia == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= nivelIncidencia.Id}, nivelIncidencia);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NivelIncidencia>> Post(NivelIncidenciaDto nivelIncidenciaDto){
        var nivelIncidencia = _mapper.Map<NivelIncidencia>(nivelIncidenciaDto);
        this._unitOfWork.NivelIncidencias.Add(nivelIncidencia);
        await _unitOfWork.SaveAsync();
        if (nivelIncidencia == null)
        {
            return BadRequest();
        }
        nivelIncidenciaDto.Id = nivelIncidencia.Id;
        return CreatedAtAction(nameof(Post),new {id= nivelIncidenciaDto.Id}, nivelIncidenciaDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area nivelIncidencia){
        if(nivelIncidencia == null)
            return NotFound();
        _unitOfWork.NivelIncidencias.Update(nivelIncidencia);
        await _unitOfWork.SaveAsync();
        return nivelIncidencia;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NivelIncidenciaDto>> Put(int id, [FromBody]NivelIncidenciaDto nivelIncidenciaDto){
        if(nivelIncidenciaDto == null)
            return NotFound();
        var nivelIncidencias = _mapper.Map<NivelIncidencia>(nivelIncidenciaDto);
        _unitOfWork.NivelIncidencias.Update(nivelIncidencias);
        await _unitOfWork.SaveAsync();
        return nivelIncidenciaDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var nivelIncidencia = await _unitOfWork.NivelIncidencias.GetByIdAsync(id);
        if(nivelIncidencia == null){
            return NotFound();
        }
        _unitOfWork.NivelIncidencias.Remove(nivelIncidencia);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}