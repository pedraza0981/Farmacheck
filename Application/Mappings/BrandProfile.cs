using AutoMapper;
using Farmacheck.Infrastructure.Models;
using Farmacheck.Models;

namespace Farmacheck.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandResponse, Marca>()
                .ForMember(dest => dest.UnidadDeNegocioId, opt => opt.MapFrom(src => src.UnidadDeNegocio));

            CreateMap<Marca, BrandRequest>()
                .ForMember(dest => dest.UnidadDeNegocio, opt => opt.MapFrom(src => src.UnidadDeNegocioId));
        }
    }
}
