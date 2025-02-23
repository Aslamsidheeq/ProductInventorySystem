using System.ComponentModel.DataAnnotations;

namespace Inventory_system.Dtos
{
    public class StockRequestDto
    {
        public Guid SubVariantId { get; set; }
        [Required]
        public decimal Stock { get; set; }
    }
}
