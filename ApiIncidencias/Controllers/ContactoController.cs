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

// Contacto, contacto, Contactos, contactos

public class ContactoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContactoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Contacto>>> Get()
    {
        var regiones = await _unitOfWork.Contactos.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<ContactoDto>>> Get()
    {
        var contactos = await _unitOfWork.Contactos.GetAllAsync();
        return _mapper.Map<List<ContactoDto>>(contactos);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ContactoDto>>> Get11([FromQuery] Params contactoParams)
    {
        var contacto = await _unitOfWork.Contactos.GetAllAsync(contactoParams.PageIndex,contactoParams.PageSize,contactoParams.Search);
        var lstContactosDto = _mapper.Map<List<ContactoDto>>(contacto.registros);
        return new Pager<ContactoDto>(lstContactosDto,contacto.totalRegistros,contactoParams.PageIndex,contactoParams.PageSize,contactoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContactoDto>> Get(int id)
    {
        var contacto = await _unitOfWork.Contactos.GetByIdAsync(id);
        if (contacto == null){
            return NotFound();
        }
        return _mapper.Map<ContactoDto>(contacto);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contacto>> Post(Contacto contacto){
        this._unitOfWork.Contactos.Add(contacto);
        await _unitOfWork.SaveAsync();
        if (contacto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= contacto.Id}, contacto);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contacto>> Post(ContactoDto contactoDto){
        var contacto = _mapper.Map<Contacto>(contactoDto);
        this._unitOfWork.Contactos.Add(contacto);
        await _unitOfWork.SaveAsync();
        if (contacto == null)
        {
            return BadRequest();
        }
        contactoDto.Id = contacto.Id;
        return CreatedAtAction(nameof(Post),new {id= contactoDto.Id}, contactoDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area contacto){
        if(contacto == null)
            return NotFound();
        _unitOfWork.Contactos.Update(contacto);
        await _unitOfWork.SaveAsync();
        return contacto;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactoDto>> Put(int id, [FromBody]ContactoDto contactoDto){
        if(contactoDto == null)
            return NotFound();
        var contactos = _mapper.Map<Contacto>(contactoDto);
        _unitOfWork.Contactos.Update(contactos);
        await _unitOfWork.SaveAsync();
        return contactoDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var contacto = await _unitOfWork.Contactos.GetByIdAsync(id);
        if(contacto == null){
            return NotFound();
        }
        _unitOfWork.Contactos.Remove(contacto);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}