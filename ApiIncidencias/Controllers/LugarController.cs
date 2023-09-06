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

// Lugar, lugar, Lugares, lugares

public class LugarController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LugarController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Lugar>>> Get()
    {
        var regiones = await _unitOfWork.Lugares.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<LugarDto>>> Get()
    {
        var lugares = await _unitOfWork.Lugares.GetAllAsync();
        return _mapper.Map<List<LugarDto>>(lugares);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LugarDto>>> Get11([FromQuery] Params lugarParams)
    {
        var lugar = await _unitOfWork.Lugares.GetAllAsync(lugarParams.PageIndex,lugarParams.PageSize,lugarParams.Search);
        var lstLugaresDto = _mapper.Map<List<LugarDto>>(lugar.registros);
        return new Pager<LugarDto>(lstLugaresDto,lugar.totalRegistros,lugarParams.PageIndex,lugarParams.PageSize,lugarParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LugarDto>> Get(int id)
    {
        var lugar = await _unitOfWork.Lugares.GetByIdAsync(id);
        if (lugar == null){
            return NotFound();
        }
        return _mapper.Map<LugarDto>(lugar);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Lugar>> Post(Lugar lugar){
        this._unitOfWork.Lugares.Add(lugar);
        await _unitOfWork.SaveAsync();
        if (lugar == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= lugar.Id}, lugar);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Lugar>> Post(LugarDto lugarDto){
        var lugar = _mapper.Map<Lugar>(lugarDto);
        this._unitOfWork.Lugares.Add(lugar);
        await _unitOfWork.SaveAsync();
        if (lugar == null)
        {
            return BadRequest();
        }
        lugarDto.Id = lugar.Id;
        return CreatedAtAction(nameof(Post),new {id= lugarDto.Id}, lugarDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area lugar){
        if(lugar == null)
            return NotFound();
        _unitOfWork.Lugares.Update(lugar);
        await _unitOfWork.SaveAsync();
        return lugar;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LugarDto>> Put(int id, [FromBody]LugarDto lugarDto){
        if(lugarDto == null)
            return NotFound();
        var lugares = _mapper.Map<Lugar>(lugarDto);
        _unitOfWork.Lugares.Update(lugares);
        await _unitOfWork.SaveAsync();
        return lugarDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var lugar = await _unitOfWork.Lugares.GetByIdAsync(id);
        if(lugar == null){
            return NotFound();
        }
        _unitOfWork.Lugares.Remove(lugar);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}