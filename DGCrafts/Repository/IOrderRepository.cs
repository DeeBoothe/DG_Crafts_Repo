using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGCrafts.Models;

namespace DGCrafts.Repository
{
    public interface IOrderRepository
    {
        List<ShippingInfo> GetOrders();
        ShippingInfo GetOrder(int orderId);
        void CancelOrder(int orderId);
        void SaveOrder(ShippingInfo order);
    }
}
