using orderManagement.webApi.Model;
using System.Collections.Generic;

public interface IOrderService
{
    IEnumerable<OrderDetails> GetAllOrderDetails();
    void AddOrder(OrderDetails order);
    void UpdateOrder(int orderId, OrderDetails order);
    void DeleteOrder(List<int> orderId);
}
