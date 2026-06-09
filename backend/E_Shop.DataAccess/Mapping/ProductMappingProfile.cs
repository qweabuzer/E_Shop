using AutoMapper;
using E_Shop.Core.Models;
using E_Shop.DataAccess.Entities;

namespace E_Shop.DataAccess.Mapping;
public class ProductMappingProfile : Profile
{
	public ProductMappingProfile()
	{
		CreateProductMapping();
	}

	private void CreateProductMapping()
	{
		CreateMap<ProductEntity, Product>();
		CreateMap<Product, ProductEntity>();
	}
}
