using Application.Features.Products.Commands;
using Application.Features.Products.Notifications;
using Application.Interfaces;
using Domain.Mapper;
using MediatR;

namespace Application.Features.Products.Handlers
{
    public class CreateProductHandler(IApplicationDbContext context, IPublisher publisher) : IRequestHandler<CreateProductCommand>
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IPublisher _publisher = publisher;

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product.FromRequest();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            await _publisher.Publish(new ProductCreatedNotification(product), cancellationToken);

            return;
        }
    }
}
