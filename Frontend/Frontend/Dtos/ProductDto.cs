namespace Frontend.Dtos
{
    public class ProductDto
    {
        public string ProductName { get; set; } = null!;
        public virtual List<VariantDto> Variants { get; set; } = new List<VariantDto>();
    }
}
