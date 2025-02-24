using Inventory_system.Dtos;
using Inventory_system.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_system.Services
{
    public class ProductService:IProductService
    {

        // to be Replaced - synchronous database operations with asynchronous 
      

        private readonly InventorySystemContext _context;
        public ProductService(InventorySystemContext context)
        {
            _context = context;
            //logging to be added - to track errors and events
        }
        //creates a new product with variants and sub variants
        public Product CreateProduct(ProductDto productDto)
        {
            if (productDto == null)
            {
                throw new ArgumentNullException("Product data cannot be null.");
            }
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                ProductName = productDto.ProductName,
                ProductCode = "XU2", //just hardcoded sample
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
                        Stock = 0 //default value at start
                    }).ToList()
                };
                product.Variants.Add(variant);
            }
            try
            {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
            }
            catch
            {
                throw new ApplicationException("An error occurred on creating product");
            }
        }
        // add stock qunatity to sub variant
        public async Task AddStock([FromBody]StockRequestDto addStock)
        {
            var subVar =  _context.SubVariants.Find(addStock.SubVariantId);
            if (subVar == null)
            {
                throw new ArgumentNullException("Subvariant not found");
            }
            subVar.Stock += addStock.Stock;
            await _context.SaveChangesAsync();
        }
        //to remove/decrease stock qunatity - similar to AddStock
        public void RemoveStock([FromBody] StockRequestDto addStock)
        {
            var subVar = _context.SubVariants.Find(addStock.SubVariantId);
            if (subVar == null)
            {
                throw new ArgumentNullException("Subvariant not found");
            }
            subVar.Stock -= addStock.Stock;
            _context.SaveChangesAsync();
        }
        //List all products with variants and sub variants
        public async Task<List<ProductDto>> ListProducts()
        {
            var products = await _context.Products.Include(p => p.Variants)
            .ThenInclude(v => v.SubVariants)
            .Select(p => new ProductDto
            {

                ProductName = p.ProductName,

                Variants = p.Variants.Select(v => new VariantDto
                {
                    VariantName = v.VariantName,
                    SubVariants = v.SubVariants.Select(sv => new SubVariantDto
                    {
                        SubVariantName = sv.SubVariantName,
                    }).ToList()
                }).ToList()
            })
            .ToListAsync();
            return products;
        }

    }
}
