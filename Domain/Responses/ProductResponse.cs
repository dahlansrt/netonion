using Domain.Common;

namespace Domain.Responses
{
    public class ProductResponse : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Sku { get; set; }
    }
}
