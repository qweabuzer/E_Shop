using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Contracts.Commands;
public record CreateProductCommand : IRequest<ActionResult<Guid>>
{
	public required string Name { get; init; }
	public required string Description { get; init; }
	public decimal Price { get; init; }
	public Guid? CategoryId { get; init; }
	public required string Image { get; init; }
	public bool IsAvailable { get; init; }
}
