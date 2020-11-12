using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DGCrafts.Models;

namespace DGCrafts.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private DGCraftsContext context;

        public EFOrderRepository(DGCraftsContext ctx)
        {
            context = ctx;
        }

        public void CancelOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public ShippingInfo GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<ShippingInfo> GetOrders()
        {
            return context.Orders.ToList();
        }

        public void SaveOrder(ShippingInfo order)
        {
            context.AttachRange(order.Lines.Select(l => l.Item));
            if(order.OrderID == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}
