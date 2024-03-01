using Domain.Responses;
using MediatR;

namespace Application.Features.Products.Queries
{
    public record GetProductQuery(int Id) : IRequest<ProductResponse?>;
}
