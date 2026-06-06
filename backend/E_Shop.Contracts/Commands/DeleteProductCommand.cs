using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Contracts.Commands;
public record DeleteProductCommand : IRequest<ActionResult<Guid>>
{
	public Guid Id { get; init; }
}
