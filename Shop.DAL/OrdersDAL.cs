using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL
{
    public class OrdersDAL : IOrdersDAL
    {
        public ShopContext _context;

        public OrdersDAL(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrders()
        {
            List<Order> orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderById(int id)
        {
            Order orders = await _context.Orders.FindAsync(id);
            if (orders.OrderId == id)
            {
                return orders;
            }
            return null;
        }

        public async Task<Order> AddOrder(Order orders)
        {
            try
            {
                await _context.Orders.AddAsync(orders);
                await _context.SaveChangesAsync();
                return orders;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> RemoveOrder(int id)
        {
            try
            {
                Order orders = await _context.Orders.SingleOrDefaultAsync(item => item.OrderId == id);
                if (orders == null)
                {
                    throw new ArgumentException($"{id} is not found");
                }
                _context.Orders.Remove(orders);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Order> UpdateOrder(Order order, int id)
        {
            try
            {
                Order current = await _context.Orders.FirstOrDefaultAsync(item => item.OrderId == id);
                if (current != null)
                {
                    current.PaymentStatus = order.PaymentStatus;

                    _context.Orders.Update(current);
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
