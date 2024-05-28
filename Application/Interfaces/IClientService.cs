using Application.Dtos;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ResponseClientDto>> GetAllAsync();
        Task<ResponseClientDto> GetByCpfAsync(string cpf);
        Task<ResponseClientDto> CreateAsync(RequestClientDto client);
    }
}
