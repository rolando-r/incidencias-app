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

// TipoDocumento, tipoDocumento, TipoDocumentos, tipoDocumentos

public class TipoDocumentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoDocumentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<TipoDocumento>>> Get()
    {
        var regiones = await _unitOfWork.TipoDocumentos.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<TipoDocumentoDto>>> Get()
    {
        var tipoDocumentos = await _unitOfWork.TipoDocumentos.GetAllAsync();
        return _mapper.Map<List<TipoDocumentoDto>>(tipoDocumentos);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoDocumentoDto>>> Get11([FromQuery] Params tipoDocumentoParams)
    {
        var tipoDocumento = await _unitOfWork.TipoDocumentos.GetAllAsync(tipoDocumentoParams.PageIndex,tipoDocumentoParams.PageSize,tipoDocumentoParams.Search);
        var lstTipoDocumentosDto = _mapper.Map<List<TipoDocumentoDto>>(tipoDocumento.registros);
        return new Pager<TipoDocumentoDto>(lstTipoDocumentosDto,tipoDocumento.totalRegistros,tipoDocumentoParams.PageIndex,tipoDocumentoParams.PageSize,tipoDocumentoParams.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoDocumentoDto>> Get(int id)
    {
        var tipoDocumento = await _unitOfWork.TipoDocumentos.GetByIdAsync(id);
        if (tipoDocumento == null){
            return NotFound();
        }
        return _mapper.Map<TipoDocumentoDto>(tipoDocumento);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumento>> Post(TipoDocumento tipoDocumento){
        this._unitOfWork.TipoDocumentos.Add(tipoDocumento);
        await _unitOfWork.SaveAsync();
        if (tipoDocumento == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= tipoDocumento.Id}, tipoDocumento);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumento>> Post(TipoDocumentoDto tipoDocumentoDto){
        var tipoDocumento = _mapper.Map<TipoDocumento>(tipoDocumentoDto);
        this._unitOfWork.TipoDocumentos.Add(tipoDocumento);
        await _unitOfWork.SaveAsync();
        if (tipoDocumento == null)
        {
            return BadRequest();
        }
        tipoDocumentoDto.Id = tipoDocumento.Id;
        return CreatedAtAction(nameof(Post),new {id= tipoDocumentoDto.Id}, tipoDocumentoDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area tipoDocumento){
        if(tipoDocumento == null)
            return NotFound();
        _unitOfWork.TipoDocumentos.Update(tipoDocumento);
        await _unitOfWork.SaveAsync();
        return tipoDocumento;
        
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumentoDto>> Put(int id, [FromBody]TipoDocumentoDto tipoDocumentoDto){
        if(tipoDocumentoDto == null)
            return NotFound();
        var tipoDocumentos = _mapper.Map<TipoDocumento>(tipoDocumentoDto);
        _unitOfWork.TipoDocumentos.Update(tipoDocumentos);
        await _unitOfWork.SaveAsync();
        return tipoDocumentoDto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var tipoDocumento = await _unitOfWork.TipoDocumentos.GetByIdAsync(id);
        if(tipoDocumento == null){
            return NotFound();
        }
        _unitOfWork.TipoDocumentos.Remove(tipoDocumento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}