namespace Frontend.Models
{
    public partial class SubVariant
    {
        public Guid Id { get; set; }

        public Guid? VariantId { get; set; }

        public string SubVariantName { get; set; } = null!;

        public decimal? Stock { get; set; }

        public virtual Variant? Variant { get; set; }
    }
}
