using AutoMapper;
using Shop.DAL.Entities;
using Shop.DAL;
using Shop.DTO.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BL
{
    public class ProductsBL : IProductsBL
    {
        IProductsDAL _productDAL;
        IMapper _mapper;

        public ProductsBL(IProductsDAL productDAL, IMapper mapper)
        {
            _productDAL = productDAL;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await _productDAL.GetProducts();
            return products;

        }

        public async Task<Product> GetProductById(int productId)
        {
            Product currentProduct = await _productDAL.GetProductById(productId);
            return currentProduct;
        }

        public async Task<ProductDTO> AddProduct(ProductDTO product)
        {
            Product u = _mapper.Map<Product>(product);
            Product isAdd = await _productDAL.AddProduct(u);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(isAdd);
            return productDTO;
        }

        public async Task<bool> RemoveProduct(int productId)
        {
            int u = _mapper.Map<int>(productId);
            bool isRemove = await _productDAL.RemoveProduct(u);
            return isRemove;
        }


        public async Task<ProductDTO> UpdateProduct(ProductDTO product, int productId)
        {
            Product u = _mapper.Map<Product>(product);
            Product updateProduct = await _productDAL.UpdateProduct(u, productId);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(updateProduct);
            return productDTO;
        }

    }
}

