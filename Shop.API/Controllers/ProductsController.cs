using Microsoft.AspNetCore.Mvc;
using Shop.BL;
using Shop.DAL;
using Shop.DAL.Entities;
using Shop.DTO.Mapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsBL _productBL;

        public ProductsController(IProductsBL productBL)
        {
            _productBL = productBL;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await _productBL.GetProducts();
            return products;

        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<Product> GetProductById(int productId)
        {
            Product currentProduct = await _productBL.GetProductById(productId);
            return currentProduct;
        }

        // POST api/<ProductsController>

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                ProductDTO isAddProduct = await _productBL.AddProduct(productDTO);
                return Ok(isAddProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct([FromBody] ProductDTO productDTO, int id)
        {
            try
            {
                ProductDTO updateProduct = await _productBL.UpdateProduct(productDTO, id);
                if (updateProduct != null)
                    return Ok(productDTO);
                return BadRequest();

            }
            catch (Exception ex)
            {
                string message = ex.Message + "somthing went wrong";
                throw new Exception(message);
            }
        }


        // DELETE api/<ProductsController>/5

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveProduct([FromBody] int id)
        {
            try
            {
                bool isRemoveProduct = await _productBL.RemoveProduct(id);
                return isRemoveProduct;
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
                
    }
}
