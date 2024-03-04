using Application.Features.Products.Commands;
using Application.Features.Products.Notifications;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Handlers
{
    public class UpdateProductHandler(IApplicationDbContext context, IPublisher publisher) : IRequestHandler<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IPublisher _publisher = publisher;
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            // How to handle Not Found?
            if (product == null) return;

            product.Name = request.Product.Name;
            product.Description = request.Product.Description;
            product.Sku = request.Product.Sku;

            await _context.SaveChangesAsync();

            await _publisher.Publish(new ProductUpdatedNotification(product), cancellationToken);

            return;
        }
    }
}
