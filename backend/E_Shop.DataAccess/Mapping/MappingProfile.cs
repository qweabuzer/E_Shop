using AutoMapper;
using E_Shop.DataAccess.Entities;
using Electronics_shop.Core;

namespace E_Shop.DataAccess.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, Users>()
            .ConstructUsing(src => Users.Create(
                src.Id,
                src.Name,
                src.Email,
                src.Login,
                src.Password,
                src.ProfileImage).Value).ReverseMap();
        }
    }
}
