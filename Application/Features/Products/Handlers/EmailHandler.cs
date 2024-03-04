using Application.Features.Products.Notifications;
using MediatR;

namespace Application.Features.Products.Handlers
{
    public class EmailHandler : INotificationHandler<ProductCreatedNotification>,
        INotificationHandler<ProductUpdatedNotification>,
        INotificationHandler<ProductDeletedNotification>
    {
        public async Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Email sent: {notification.Product.Name} is created");
            await Task.CompletedTask;
        }

        public async Task Handle(ProductUpdatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Email sent: {notification.Product.Name} is updated");
            await Task.CompletedTask;
        }

        public async Task Handle(ProductDeletedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Email sent: {notification.Product.Name} is deleted");
            await Task.CompletedTask;
        }
    }
}
