using AutoMapper;
using SharpCodingAPI.Domains.DTO.Requests;
using SharpCodingAPI.Domains.Models;

namespace SharpCodingAPI.Domains.Profiles;

public class UserProfile : Profile
{
    public UserProfile() : base(){
        CreateMap<CreateUserDto, User>();
    }

}