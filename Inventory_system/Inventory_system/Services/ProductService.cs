using Inventory_system.Dtos;
using Inventory_system.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_system.Services
{
    public class ProductService:IProductService
    {
        private readonly InventorySystemContext _context;
        public ProductService(InventorySystemContext context)
        {
            _context = context;
        }
        public Product CreateProduct(ProductDto productDto)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                ProductName = productDto.ProductName,
                ProductCode = "XU2",
                CreatedDate = DateTimeOffset.UtcNow,
                UpdatedDate = DateTimeOffset.UtcNow
            };
            foreach (var v in productDto.Variants)
            {
                var variant = new Variant
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    VariantName = v.VariantName,
                    SubVariants = v.SubVariants.Select(o => new SubVariant
                    {
                        Id = Guid.NewGuid(),
                        SubVariantName = o.SubVariantName,
                        Stock = 0
                    }).ToList()
                };
                product.Variants.Add(variant);
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
        public async Task AddStock([FromBody]StockRequestDto addStock)
        {
            var subVar =  _context.SubVariants.Find(addStock.SubVariantId);
            if (subVar == null)
            {
                return ;
            }
            subVar.Stock += addStock.Stock;
             await _context.SaveChangesAsync();
        }
        public void RemoveStock([FromBody] StockRequestDto addStock)
        {
            var subVar = _context.SubVariants.Find(addStock.SubVariantId);
            if (subVar == null)
            {
                return;
            }
            subVar.Stock -= addStock.Stock;
            _context.SaveChangesAsync();
        }
        public List<Product> ListProducts()
        {
            var products = _context.Products.Include(p => p.Variants)
            .ThenInclude(v => v.SubVariants)
        .ToList();
            return products;
        }

    }
}
