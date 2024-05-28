﻿using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPaymentRepository
    {
        void Add(Payment payment);
        void Update(Payment payment);
        void Remove(Payment payment);
        Payment GetById(int id);
        IEnumerable<Payment> GetByOrderId(int orderId);
        void SaveChanges();
    }
}
