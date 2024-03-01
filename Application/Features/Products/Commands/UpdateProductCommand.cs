using Domain.Requests;
using MediatR;

namespace Application.Features.Products.Commands
{
    public record UpdateProductCommand(int Id, ProductRequest Product) : IRequest;
}
