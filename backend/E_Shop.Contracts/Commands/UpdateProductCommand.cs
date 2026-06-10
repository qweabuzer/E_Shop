using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Contracts.Commands;
public class UpdateProductCommand : IRequest<ActionResult<Guid>>
{
	public Guid Id { get; init; }
	public string? Name { get; init; }
	public string? Description { get; init; }
	public decimal? Price { get; init; }
	public Guid? CategoryId { get; init; }
	public string? Image { get; init; }
	public bool IsAvailable { get; init; }
}
