using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Payment payment)
        {
            _context.Payments.Add(payment);
        }

        public void Update(Payment payment)
        {
            _context.Payments.Update(payment);
        }

        public void Remove(Payment payment)
        {
            _context.Payments.Remove(payment);
        }

        public Payment GetById(int id)
        {
            return _context.Payments.Include(p => p.Order).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Payment> GetByOrderId(int orderId)
        {
            return _context.Payments.Include(p => p.Order).Where(p => p.OrderId == orderId).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
