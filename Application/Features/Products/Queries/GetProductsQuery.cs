using Domain.Responses;
using MediatR;

namespace Application.Features.Products.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<ProductResponse>>;
}
