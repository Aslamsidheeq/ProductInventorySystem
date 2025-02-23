using Inventory_system.Dtos;
using Inventory_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_system.Services
{
    public interface IProductService
    {
        public Product CreateProduct(ProductDto productDto);
        public Task AddStock(StockRequestDto addStock);
        public void RemoveStock(StockRequestDto addStock);
        public List<Product> ListProducts();

    }
}
