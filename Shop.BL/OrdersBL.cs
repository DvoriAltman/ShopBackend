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
    public class OrdersBL : IOrdersBL
    {
        IOrdersDAL _orderDAL;
        IMapper _mapper;

        public OrdersBL(IOrdersDAL orderDAL, IMapper mapper)
        {
            _orderDAL = orderDAL;
            _mapper = mapper;
        }

        public async Task<List<Order>> GetOrders()
        {
            List<Order> orders = await _orderDAL.GetOrders();
            return orders;

        }

        public async Task<Order> GetOrderById(int orderId)
        {
            Order currentOrder = await _orderDAL.GetOrderById(orderId);
            return currentOrder;
        }

        public async Task<OrderDTO> AddOrder(OrderDTO order)
        {
            Order u = _mapper.Map<Order>(order);
            Order isAdd = await _orderDAL.AddOrder(u);
            OrderDTO orderDTO = _mapper.Map<OrderDTO>(isAdd);
            return orderDTO;
        }

        public async Task<bool> RemoveOrder(int orderId)
        {
            int u = _mapper.Map<int>(orderId);
            bool isRemove = await _orderDAL.RemoveOrder(u);
            return isRemove;
        }


        public async Task<OrderDTO> UpdateOrder(OrderDTO order, int orderId)
        {
            Order u = _mapper.Map<Order>(order);
            Order updateOrder = await _orderDAL.UpdateOrder(u, orderId);
            OrderDTO orderDTO = _mapper.Map<OrderDTO>(updateOrder);
            return orderDTO;
        }

    }
}
