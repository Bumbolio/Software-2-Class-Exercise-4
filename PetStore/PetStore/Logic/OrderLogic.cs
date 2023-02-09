using PetStore.Data;
using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrderLogic(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public void AddOrder(Order order)
        {
            _ordersRepository.AddOrder(order);
        }

        public List<Order> GetAllOrders()
        {
            return _ordersRepository.GetAllOrders();
        }
    }
}
