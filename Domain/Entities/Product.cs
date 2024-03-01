using Domain.Common;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Sku { get; set; }
    }
}
