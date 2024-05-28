using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByCpfAsync(string cpf);
        Task CreateAsync(Client client);
    }
}
