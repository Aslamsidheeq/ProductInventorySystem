using Inventory_system.Models;
using System.ComponentModel.DataAnnotations;

namespace Inventory_system.Dtos
{
    public class VariantDto
    {
        [Required]
        public string VariantName { get; set; } = null!;
        public virtual ICollection<SubVariantDto> SubVariants { get; set; } = new List<SubVariantDto>();

    }
}
