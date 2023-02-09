using PetStore.Data.Models;

namespace PetStore.Data
{
    public interface IOrdersRepository
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();
    }
}