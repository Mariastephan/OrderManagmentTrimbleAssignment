using Microsoft.EntityFrameworkCore;
using orderManagement.webApi.DataContext;
using orderManagement.webApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using orderManagement.webApi.Model;

namespace orderManagement.webApi.DataAccess
{
    public class OrderService : IOrderService
    {
        #region MememberFunction
        private readonly OrderDetailsDbContext _context;
        #endregion

        #region Constructor
        public OrderService(OrderDetailsDbContext context)
        {
            _context = context;
        }
        #endregion

        #region GetAllOrderDetails
        public IEnumerable<OrderDetails> GetAllOrderDetails()
        {
            return _context.OrderDetails.ToList();
        }
        #endregion

        #region Add Order
        public void AddOrder(OrderDetails order)
        {
            _context.OrderDetails.Add(order);
            _context.SaveChanges();
        }
        #endregion

        #region Update Order by id
        public void UpdateOrder(int orderId, OrderDetails updatedOrder)
        {
            var existingOrder = _context.OrderDetails.FirstOrDefault(o => o.OrderId == orderId);

            if (existingOrder != null)
            {
                existingOrder.OrderDate = updatedOrder.OrderDate;
                existingOrder.OrderNumber = updatedOrder.OrderNumber;
                existingOrder.OrderAmount = updatedOrder.OrderAmount;
                existingOrder.Vendor = updatedOrder.Vendor;
                existingOrder.Shop = updatedOrder.Shop;
                existingOrder.LastModifiedDate = DateTime.Now;

                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Order not found.");
            }
        }
        #endregion

        #region Delete Order by id
        public void DeleteOrder(List<int> orderId)
        {
            
            var ordersToDelete = _context.OrderDetails.Where(o => orderId.Contains(o.OrderId)).ToList();
            if (ordersToDelete.Count() > 0)
            {

                foreach (var order in ordersToDelete)
                {
                    _context.OrderDetails.Remove(order);
                }
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Order not found.");
            }
        }
        #endregion

    }
}
