using Frontend.Dtos;
using System.Net.Http;
using System.Net.Http.Json;
namespace Frontend.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient ;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task addProductService(ProductDto product)
        {
            await _httpClient.PostAsJsonAsync("CreateProduct", product);
        }
    }
}
