namespace Frontend.Dtos
{
    public class VariantDto
    {
        public string VariantName { get; set; } = null!;
        public virtual List<SubVariantDto> SubVariants { get; set; } = new List<SubVariantDto>();

    }
}
