using System.Collections.Generic;

namespace SportsStoreWebAPI.Models
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        IEnumerable<OrderDetail> GetOrderDetail(int orderID);
        OrderDetail AddOrderDetail(OrderDetail orderDetail);
        void RemoveOrderDetail(int orderID);
        bool UpdateOrderDetail(OrderDetail orderDetail);
    }
}
