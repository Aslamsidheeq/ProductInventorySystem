using Inventory_system.Models;
using System.ComponentModel.DataAnnotations;

namespace Inventory_system.Dtos
{
    public class SubVariantDto
    {
        [Required]
        public string SubVariantName { get; set; } = null!;
    }
}
