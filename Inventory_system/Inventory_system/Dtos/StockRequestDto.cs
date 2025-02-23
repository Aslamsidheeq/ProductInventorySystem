namespace Inventory_system.Dtos
{
    public class StockRequestDto
    {
        public Guid SubVariantId { get; set; }
        public decimal Stock { get; set; }
    }
}
