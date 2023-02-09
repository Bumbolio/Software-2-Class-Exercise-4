using PetStore.Data.Models;

namespace PetStore.Logic
{
    public interface IOrderLogic
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();
    }
}