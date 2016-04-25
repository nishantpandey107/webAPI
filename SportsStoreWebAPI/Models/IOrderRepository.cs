using System.Collections.Generic;

namespace SportsStoreWebAPI.Models
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int orderID);
        Order AddOrder(Order order);
        void RemoveOrder(int orderID);
        bool UpdateOrder(Order order);
    }
}
