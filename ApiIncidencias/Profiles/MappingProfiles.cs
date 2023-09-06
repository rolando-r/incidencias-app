using ApiIncidencias.Dtos;
using AutoMapper;
using Dominio;

namespace IncApi.Profiles;



public class MappingProfiles :Profile
{
    public MappingProfiles()
    {
        CreateMap<Area,AreaDto>()
        .ReverseMap()
        .ForMember(o => o.Lugares, d => d.Ignore());

        CreateMap<Area,AreaxLugarDto>().ReverseMap();

        CreateMap<CategoriaContacto,CategoriaContactoDto>().ReverseMap();
        CreateMap<Contacto,ContactoDto>().ReverseMap();
        CreateMap<DetalleIncidencia,DetalleIncidenciaDto>().ReverseMap();
        CreateMap<Estado, EstadoDto>().ReverseMap();
        CreateMap<Incidencia, IncidenciaDto>().ReverseMap();
        CreateMap<Lugar, LugarDto>().ReverseMap();
        CreateMap<NivelIncidencia, NivelIncidenciaDto>().ReverseMap();
        CreateMap<Periferico, PerifericoDto>().ReverseMap();
        CreateMap<Persona, PersonaDto>().ReverseMap();
        CreateMap<TipoContacto, TipoContactoDto>().ReverseMap();
        CreateMap<TipoDocumento, TipoDocumentoDto>().ReverseMap();
        CreateMap<TipoIncidencia, TipoIncidenciaDto>().ReverseMap();
    }
}