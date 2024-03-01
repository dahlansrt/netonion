namespace Domain.Requests
{
    /// <summary>
    /// Use for Create & Update.
    /// Use this if Create & Update is the same model.
    /// </summary>
    public class ProductRequest
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Sku { get; set; }
    }

    /// <summary>
    /// If there is a requirement for diferent Request model
    /// </summary>
    public class CreateProductRequest
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Sku { get; set; }
    }

    /// <summary>
    /// If there is a requirement for diferent Request model
    /// </summary>
    public class UpdateProductRequest
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Sku { get; set; }
    }
}
