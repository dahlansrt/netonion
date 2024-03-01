using Application.Features.Products.Queries;
using Application.Interfaces;
using Domain.Mapper;
using Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Handlers
{
    public class GetProductHandler(IApplicationDbContext context) : IRequestHandler<GetProductQuery, ProductResponse?>
    {
        private readonly IApplicationDbContext context = context;

        public async Task<ProductResponse?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return product?.ToResponse() ?? null;
        }
    }
}
