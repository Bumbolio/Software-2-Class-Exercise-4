using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ProductContext _ctx;
        public OrdersRepository()
        {
            _ctx = new ProductContext();
        }

        public void AddOrder(Order order)
        {
            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            var orders = _ctx.Orders.ToList();
            return orders;
        }
    }
}
