using Application.Dtos;


namespace Application.Interfaces
{
    public interface IClientUseCase
    {
        Task<IEnumerable<ResponseClientDto>> GetAllAsync();
        Task<ResponseClientDto> GetByCpfAsync(string cpf);
        Task<ResponseClientDto> CreateAsync(RequestClientDto client);
    }
}
