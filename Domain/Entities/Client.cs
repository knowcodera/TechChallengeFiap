using Domain.ValueObjects;
using System.ComponentModel;

namespace Domain.Entities
{
    public class Client
    {
        public Client()
        {

        }
        public Client(string name, string cpf, string email)
        {
            Name = name;
            Cpf = new CPF(cpf);
            Email = email;
        }

        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; private set; }

        [DisplayName("CPF")]
        public CPF Cpf { get; private set; }

        [DisplayName("E-mail")]
        public string Email { get; private set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
