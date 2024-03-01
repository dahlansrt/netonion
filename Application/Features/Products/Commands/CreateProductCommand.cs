using Domain.Requests;
using MediatR;

namespace Application.Features.Products.Commands
{
    public record CreateProductCommand(ProductRequest Product) : IRequest;
}
