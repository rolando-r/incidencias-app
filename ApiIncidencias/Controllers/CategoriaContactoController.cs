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

// CategoriaContacto, categoriaContacto, CategoriaContactos, categoriaContactos

public class CategoriaContactoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriaContactoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<CategoriaContacto>>> Get()
    {
        var regiones = await _unitOfWork.CategoriaContactos.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<CategoriaContactoDto>>> Get()
    {
        var categoriaContactos = await _unitOfWork.CategoriaContactos.GetAllAsync();
        return _mapper.Map<List<CategoriaContactoDto>>(categoriaContactos);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CategoriaContactoDto>>> Get11([FromQuery] Params categoriaContactoParams)
    {
        var categoriaContacto = await _unitOfWork.CategoriaContactos.GetAllAsync(categoriaContactoParams.PageIndex,categoriaContactoParams.PageSize,categoriaContactoParams.Search);
        var lstCategoriaContactosDto = _mapper.Map<List<CategoriaContactoDto>>(categoriaContacto.registros);
        return new Pager<CategoriaContactoDto>(lstCategoriaContactosDto,categoriaContacto.totalRegistros,categoriaContactoParams.PageIndex,categoriaContactoParams.PageSize,categoriaContactoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaContactoDto>> Get(int id)
    {
        var categoriaContacto = await _unitOfWork.CategoriaContactos.GetByIdAsync(id);
        if (categoriaContacto == null){
            return NotFound();
        }
        return _mapper.Map<CategoriaContactoDto>(categoriaContacto);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaContacto>> Post(CategoriaContacto categoriaContacto){
        this._unitOfWork.CategoriaContactos.Add(categoriaContacto);
        await _unitOfWork.SaveAsync();
        if (categoriaContacto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= categoriaContacto.Id}, categoriaContacto);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaContacto>> Post(CategoriaContactoDto categoriaContactoDto){
        var categoriaContacto = _mapper.Map<CategoriaContacto>(categoriaContactoDto);
        this._unitOfWork.CategoriaContactos.Add(categoriaContacto);
        await _unitOfWork.SaveAsync();
        if (categoriaContacto == null)
        {
            return BadRequest();
        }
        categoriaContactoDto.Id = categoriaContacto.Id;
        return CreatedAtAction(nameof(Post),new {id= categoriaContactoDto.Id}, categoriaContactoDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area categoriaContacto){
        if(categoriaContacto == null)
            return NotFound();
        _unitOfWork.CategoriaContactos.Update(categoriaContacto);
        await _unitOfWork.SaveAsync();
        return categoriaContacto;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaContactoDto>> Put(int id, [FromBody]CategoriaContactoDto categoriaContactoDto){
        if(categoriaContactoDto == null)
            return NotFound();
        var categoriaContactos = _mapper.Map<CategoriaContacto>(categoriaContactoDto);
        _unitOfWork.CategoriaContactos.Update(categoriaContactos);
        await _unitOfWork.SaveAsync();
        return categoriaContactoDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var categoriaContacto = await _unitOfWork.CategoriaContactos.GetByIdAsync(id);
        if(categoriaContacto == null){
            return NotFound();
        }
        _unitOfWork.CategoriaContactos.Remove(categoriaContacto);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}