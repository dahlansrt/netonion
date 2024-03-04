using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Notifications
{
    public record ProductCreatedNotification(Product Product) : INotification;
    public record ProductUpdatedNotification(Product Product) : INotification;
    public record ProductDeletedNotification(Product Product) : INotification;
}
