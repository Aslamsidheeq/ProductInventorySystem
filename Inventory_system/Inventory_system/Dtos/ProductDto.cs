using Inventory_system.Models;
using System.ComponentModel.DataAnnotations;

namespace Inventory_system.Dtos
{
    public class ProductDto
    {
        [Required]
        public string ProductName { get; set; } = null!;
        public virtual ICollection<VariantDto> Variants { get; set; } = new List<VariantDto>();

    }
}
