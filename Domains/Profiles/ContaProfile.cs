using AutoMapper;
using SharpCodingAPI.Domains.DTO.Responses;
using SharpCodingAPI.Domains.Models;

namespace SharpCodingAPI.Domains.Profiles;

public class ContaProfile : Profile
{
    public ContaProfile() : base(){
       CreateMap<User, ContaResponseDto>();
                // .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                // .ForMember(dest => dest.Saldo, opt => opt.MapFrom(src => src.Saldo))
                // .ForMember(dest => dest.NumeroConta, opt => opt.MapFrom(src => src.NumeroConta))
                // .ForMember(dest => dest.Agencia, opt => opt.MapFrom(src => src.Agencia));
    }

}