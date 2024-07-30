using AutoMapper;
using Bootcamp.Application.Models;
using Bootcamp.Domain.Entities;

namespace Bootcamp.Application.Profiles;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}