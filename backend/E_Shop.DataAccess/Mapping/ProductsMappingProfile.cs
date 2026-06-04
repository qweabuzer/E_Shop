using AutoMapper;
using E_Shop.Core.Models;
using E_Shop.DataAccess.Entities;

namespace E_Shop.DataAccess.Mapping;
public class ProductsMappingProfile : Profile
{
	public ProductsMappingProfile()
	{
		CreateProductMapping();
	}

	private void CreateProductMapping()
	{
		CreateMap<ProductEntity, Product>();
		CreateMap<Product, ProductEntity>();
	}
}
