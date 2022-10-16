using EntityFrameworkSP_Demo.Entities;

namespace EntityFrameworkSP_Demo.Repositories
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductListAsync();
        public Task<IEnumerable<Product>> GetProductByIdAsync(int Id);
        public Task<int> AddProductAsync(Product product);
        public Task<int> UpdateProductAsync(Product product);
        public Task<int> DeleteProductAsync(int Id);
    }
}
