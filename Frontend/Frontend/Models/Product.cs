namespace Frontend.Models
{
    public partial class Product
    {
        public Guid Id { get; set; }

        public string ProductCode { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public byte[]? ProductImage { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }

        public DateTimeOffset? UpdatedDate { get; set; }

        public Guid? CreatedUser { get; set; }

        public bool? IsFavourite { get; set; }

        public bool? Active { get; set; }

        public string? Hsncode { get; set; }

        public decimal? TotalStock { get; set; }

        public virtual User? CreatedUserNavigation { get; set; }

        public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();
    }
}
