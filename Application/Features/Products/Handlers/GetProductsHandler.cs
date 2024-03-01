using Application.Features.Products.Queries;
using Application.Interfaces;
using Domain.Mapper;
using Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Handlers
{
    public class GetProductsHandler(IApplicationDbContext context) : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponse>>
    {
        private readonly IApplicationDbContext context = context;

        public async Task<IEnumerable<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Products.ToListAsync(cancellationToken: cancellationToken);
            return result.ConvertAll(x => x.ToResponse());
        }
    }
}
