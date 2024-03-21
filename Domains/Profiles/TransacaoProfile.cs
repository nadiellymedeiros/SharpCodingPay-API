using AutoMapper;
using SharpCodingAPI.Domains.DTO.Responses;
using SharpCodingAPI.Domains.Models;

namespace SharpCodingAPI.Domains.Profiles;

public class TrasacaoProfile : Profile
{
    public TrasacaoProfile() : base(){
       CreateMap<Transacoes, TransacaoResponseDto>();
       
                
    }

}