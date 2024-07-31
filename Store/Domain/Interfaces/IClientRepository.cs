using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByCpfAsync(string cpf);
        Task CreateAsync(Client client);
    }
}
