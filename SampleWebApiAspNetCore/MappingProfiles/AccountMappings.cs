using AutoMapper;
using WebApiAspNetCore.Dtos;
using WebApiAspNetCore.Entities;

namespace WebApiAspNetCore.MappingProfiles
{
    public class AccountMappings : Profile
    {
        public AccountMappings() 
        {
            //Get
            CreateMap<AccountEntity, AccountDto>().ReverseMap();
            //Post
            CreateMap<AccountEntity, AccountCreateDto>().ReverseMap();
            //Update
            CreateMap<AccountEntity, AccountUpdateDto>().ReverseMap();
        }

    }
}
