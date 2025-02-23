using Inventory_system.Models;

namespace Inventory_system.Dtos
{
    public class VariantDto
    {
        public string VariantName { get; set; } = null!;
        public virtual ICollection<SubVariantDto> SubVariants { get; set; } = new List<SubVariantDto>();

    }
}
