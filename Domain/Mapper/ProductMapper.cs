using Domain.Entities;
using Domain.Requests;
using Domain.Responses;

namespace Domain.Mapper
{
    public static class ProductMapper
    {
        public static ProductResponse ToResponse(this Product product)
        {
            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Sku = product.Sku,
                Description = product.Description,
            };
        }

        public static Product FromRequest(this ProductRequest product)
        {
            return new()
            {
                Name = product.Name,
                Sku = product.Sku,
                Description = product.Description,
            };
        }
    }
}
