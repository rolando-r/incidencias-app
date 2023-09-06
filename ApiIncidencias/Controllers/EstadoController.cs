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

// Estado, estado, Estados, estados

public class EstadoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Estado>>> Get()
    {
        var regiones = await _unitOfWork.Estados.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<EstadoDto>>> Get()
    {
        var estados = await _unitOfWork.Estados.GetAllAsync();
        return _mapper.Map<List<EstadoDto>>(estados);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EstadoDto>>> Get11([FromQuery] Params estadoParams)
    {
        var estado = await _unitOfWork.Estados.GetAllAsync(estadoParams.PageIndex,estadoParams.PageSize,estadoParams.Search);
        var lstEstadosDto = _mapper.Map<List<EstadoDto>>(estado.registros);
        return new Pager<EstadoDto>(lstEstadosDto,estado.totalRegistros,estadoParams.PageIndex,estadoParams.PageSize,estadoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoDto>> Get(int id)
    {
        var estado = await _unitOfWork.Estados.GetByIdAsync(id);
        if (estado == null){
            return NotFound();
        }
        return _mapper.Map<EstadoDto>(estado);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Estado>> Post(Estado estado){
        this._unitOfWork.Estados.Add(estado);
        await _unitOfWork.SaveAsync();
        if (estado == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= estado.Id}, estado);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Estado>> Post(EstadoDto estadoDto){
        var estado = _mapper.Map<Estado>(estadoDto);
        this._unitOfWork.Estados.Add(estado);
        await _unitOfWork.SaveAsync();
        if (estado == null)
        {
            return BadRequest();
        }
        estadoDto.Id = estado.Id;
        return CreatedAtAction(nameof(Post),new {id= estadoDto.Id}, estadoDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area estado){
        if(estado == null)
            return NotFound();
        _unitOfWork.Estados.Update(estado);
        await _unitOfWork.SaveAsync();
        return estado;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody]EstadoDto estadoDto){
        if(estadoDto == null)
            return NotFound();
        var estados = _mapper.Map<Estado>(estadoDto);
        _unitOfWork.Estados.Update(estados);
        await _unitOfWork.SaveAsync();
        return estadoDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var estado = await _unitOfWork.Estados.GetByIdAsync(id);
        if(estado == null){
            return NotFound();
        }
        _unitOfWork.Estados.Remove(estado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}