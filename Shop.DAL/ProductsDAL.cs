using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL
{
    public class ProductsDAL : IProductsDAL
    {
        public ShopContext _context;

        public ProductsDAL(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int productId)
        {
            Product product = await _context.Products.FindAsync(productId);
            if (product.ProductId == productId)
            {
                return product;
            }
            return null;
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> RemoveProduct(int id)
        {
            try
            {
                Product product = await _context.Products.SingleOrDefaultAsync(item => item.ProductId == id);
                if (product == null)
                {
                    throw new ArgumentException($"{id} is not found");
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Product> UpdateProduct(Product product, int id)
        {
            try
            {
                Product current = await _context.Products.FirstOrDefaultAsync(item => item.ProductId == id);
                if (current != null)
                {
                    current.ProductName = product.ProductName;
                    current.Price = product.Price;
                    current.ImagePath = product.ImagePath;

                    _context.Products.Update(current);
                    await _context.SaveChangesAsync();
                    return current;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}
