using AutoMapper;
using E_Shop.Core.Models;
using E_Shop.DataAccess.Entities;

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
                src.ProfileImage).Value)
            .ReverseMap();

            CreateMap<ProductEntity, Product>()
                .ConstructUsing(src => Product.Create(
                    src.Id,
                    src.Name,
                    src.Description,
                    src.Price,
                    src.CategoryId,
                    src.Image,
                    src.IsAvailable).Value)
                .ReverseMap();

            CreateMap<CategoryEntity, Category>()
                .ConstructUsing(src => Category.Create(
                    src.Id,
                    src.Name,
                    src.Description).Value)
                .ReverseMap();
        }
    }
}
