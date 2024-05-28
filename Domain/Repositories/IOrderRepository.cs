using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Update(Order order);
        void Remove(Order order);
        Order GetById(int id);
        IEnumerable<Order> GetAll();
        void SaveChanges();
    }
}
