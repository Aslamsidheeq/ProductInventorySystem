namespace Frontend.Models
{
    public partial class Variant
    {
        public Guid Id { get; set; }

        public Guid? ProductId { get; set; }

        public string VariantName { get; set; } = null!;

        public virtual Product? Product { get; set; }

        public virtual ICollection<SubVariant> SubVariants { get; set; } = new List<SubVariant>();
    }
}
