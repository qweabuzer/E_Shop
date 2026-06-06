using E_Shop.Contracts.Contracts.Products;
using MediatR;

namespace E_Shop.Contracts.Queries;
public record GetAllProductsQuery : IRequest<List<ProductResponse>>;
