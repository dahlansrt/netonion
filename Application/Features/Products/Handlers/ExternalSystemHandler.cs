using Application.Features.Products.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handlers
{
    public class ExternalSystemHandler : INotificationHandler<ProductCreatedNotification>,
        INotificationHandler<ProductUpdatedNotification>,
        INotificationHandler<ProductDeletedNotification>
    {
        public async Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"API Call: {notification.Product.Name} is created");
            await Task.CompletedTask;
        }

        public async Task Handle(ProductUpdatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"API Call: {notification.Product.Name} is updated");
            await Task.CompletedTask;
        }

        public async Task Handle(ProductDeletedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"API Call: {notification.Product.Name} is deleted");
            await Task.CompletedTask;
        }
    }
}
