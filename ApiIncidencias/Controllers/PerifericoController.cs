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

// Periferico, periferico, Perifericos, perifericos

public class PerifericoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PerifericoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Periferico>>> Get()
    {
        var regiones = await _unitOfWork.Perifericos.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<PerifericoDto>>> Get()
    {
        var perifericos = await _unitOfWork.Perifericos.GetAllAsync();
        return _mapper.Map<List<PerifericoDto>>(perifericos);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PerifericoDto>>> Get11([FromQuery] Params perifericoParams)
    {
        var periferico = await _unitOfWork.Perifericos.GetAllAsync(perifericoParams.PageIndex,perifericoParams.PageSize,perifericoParams.Search);
        var lstPerifericosDto = _mapper.Map<List<PerifericoDto>>(periferico.registros);
        return new Pager<PerifericoDto>(lstPerifericosDto,periferico.totalRegistros,perifericoParams.PageIndex,perifericoParams.PageSize,perifericoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PerifericoDto>> Get(int id)
    {
        var periferico = await _unitOfWork.Perifericos.GetByIdAsync(id);
        if (periferico == null){
            return NotFound();
        }
        return _mapper.Map<PerifericoDto>(periferico);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Periferico>> Post(Periferico periferico){
        this._unitOfWork.Perifericos.Add(periferico);
        await _unitOfWork.SaveAsync();
        if (periferico == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= periferico.Id}, periferico);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Periferico>> Post(PerifericoDto perifericoDto){
        var periferico = _mapper.Map<Periferico>(perifericoDto);
        this._unitOfWork.Perifericos.Add(periferico);
        await _unitOfWork.SaveAsync();
        if (periferico == null)
        {
            return BadRequest();
        }
        perifericoDto.Id = periferico.Id;
        return CreatedAtAction(nameof(Post),new {id= perifericoDto.Id}, perifericoDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area periferico){
        if(periferico == null)
            return NotFound();
        _unitOfWork.Perifericos.Update(periferico);
        await _unitOfWork.SaveAsync();
        return periferico;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PerifericoDto>> Put(int id, [FromBody]PerifericoDto perifericoDto){
        if(perifericoDto == null)
            return NotFound();
        var perifericos = _mapper.Map<Periferico>(perifericoDto);
        _unitOfWork.Perifericos.Update(perifericos);
        await _unitOfWork.SaveAsync();
        return perifericoDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var periferico = await _unitOfWork.Perifericos.GetByIdAsync(id);
        if(periferico == null){
            return NotFound();
        }
        _unitOfWork.Perifericos.Remove(periferico);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}