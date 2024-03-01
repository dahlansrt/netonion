using Application.Features.Products.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Handlers
{
    public class DeleteProductHandler(IApplicationDbContext context) : IRequestHandler<DeleteProductCommand>
    {
        private readonly IApplicationDbContext context = context;
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            // How to handle Not Found?
            if (product == null) return;

            context.Products.Remove(product);

            await context.SaveChangesAsync();
        }
    }
}
