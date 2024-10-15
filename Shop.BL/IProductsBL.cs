using Shop.DAL.Entities;
using Shop.DTO.Mapper;

namespace Shop.BL
{
    public interface IProductsBL
    {
        public Task<ProductDTO> AddProduct(ProductDTO product);
        public Task<Product> GetProductById(int productId);
        public Task<List<Product>> GetProducts();
        public Task<bool> RemoveProduct(int productId);
        public Task<ProductDTO> UpdateProduct(ProductDTO product, int productId);
    }
}