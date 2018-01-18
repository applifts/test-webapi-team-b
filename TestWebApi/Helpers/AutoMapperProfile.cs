using AutoMapper;
using TestWebApi.Domain.Entities;
using TestWebApi.Services.Dtos;

namespace TestWebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>();
        }
    }
}