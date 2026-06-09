using AutoMapper;
using E_Shop.Core.Models;
using E_Shop.DataAccess.Entities;

namespace E_Shop.DataAccess.Mapping;
public class CategoryMappingProfile : Profile
{
	public CategoryMappingProfile()
	{
		CreateCategoryMapping();
	}

	private void CreateCategoryMapping()
	{
		CreateMap<UserEntity, Users>();
		CreateMap<Users, UserEntity>();
	}
}
