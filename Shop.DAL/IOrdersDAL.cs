using Shop.DAL.Entities;

namespace Shop.DAL
{
    public interface IOrdersDAL
    {
        public Task<Order> AddOrder(Order orders);
        public Task<List<Order>> GetOrders();
        public Task<Order> GetOrderById(int id);
        public Task<bool> RemoveOrder(int id);
        public Task<Order> UpdateOrder(Order order, int id);
    }
}