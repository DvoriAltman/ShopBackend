﻿using Shop.DAL.Entities;

namespace Shop.DAL
{
    public interface IProductsDAL
    {
        public Task<Product> AddProduct(Product product);
        public Task<Product> GetProductById(int id);
        public Task<List<Product>> GetProducts();
        public Task<bool> RemoveProduct(int id);
        public Task<Product> UpdateProduct(Product product, int id);
    }
}


