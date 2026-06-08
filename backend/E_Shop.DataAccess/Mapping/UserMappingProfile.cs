using AutoMapper;
using E_Shop.Core.Models;
using E_Shop.DataAccess.Entities;

namespace E_Shop.DataAccess.Mapping;

public class UserMappingProfile : Profile
{
	public UserMappingProfile()
	{
		CreateUserMapping();
	}

	private void CreateUserMapping()
	{
		CreateMap<UserEntity, Users>();
		CreateMap<Users, UserEntity>();
	}
}
