using Application.Features.Products.Commands;
using Application.Interfaces;
using Domain.Mapper;
using MediatR;

namespace Application.Features.Products.Handlers
{
    public class CreateProductHandler(IApplicationDbContext context) : IRequestHandler<CreateProductCommand>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _context.Products.Add(request.Product.FromRequest());
            await _context.SaveChangesAsync();

            return;
        }
    }
}
