using Shop.DAL.Entities;
using Shop.DTO.Mapper;

namespace Shop.BL
{
    public interface IOrdersBL
    {
        public Task<OrderDTO> AddOrder(OrderDTO order);
        public Task<Order> GetOrderById(int orderId);
        public Task<List<Order>> GetOrders();
        public Task<bool> RemoveOrder(int orderId);
        public Task<OrderDTO> UpdateOrder(OrderDTO order, int orderId);
    }
}