using Microsoft.AspNetCore.Mvc;
using Shop.BL;
using Shop.DAL.Entities;
using Shop.DTO.Mapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrdersBL _orderBL;


        public OrdersController(IOrdersBL orderBL)
        {
            _orderBL = orderBL;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            List<Order> orders = await _orderBL.GetOrders();
            return orders;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<Order> GetOrderById(int orderId)
        {
            Order currentOrder = await _orderBL.GetOrderById(orderId);
            return currentOrder;
        }


        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                OrderDTO isAddOrder = await _orderBL.AddOrder(orderDTO);
                return Ok(isAddOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> UpdateOrder([FromBody] OrderDTO orderDTO, int id)
        {
            try
            {
                OrderDTO updateOrder = await _orderBL.UpdateOrder(orderDTO, id);
                if (updateOrder != null)
                    return Ok(orderDTO);
                return BadRequest();

            }
            catch (Exception ex)
            {
                string message = ex.Message + "somthing went wrong";
                throw new Exception(message);
            }
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveOrder([FromBody] int id)
        {
            try
            {
                bool isRemoveOrder = await _orderBL.RemoveOrder(id);
                return isRemoveOrder;
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }


    }
}
