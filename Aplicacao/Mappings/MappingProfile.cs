using AutoMapper;
using QuadrosNBR.Aplicacao.DTOs;
using QuadrosNBR.Dominio.Entities;

namespace QuadrosNBR.Aplicacao.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MemoriaDominio, MemoriaDTO>().ReverseMap();
        CreateMap<InformacoesPreliminaresDominio, InformacoesPreliminaresDTO>().ReverseMap();
        CreateMap<PavimentoDominio, PavimentoDTO>().ReverseMap();
    }
}
