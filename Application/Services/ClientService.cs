using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientService(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ResponseClientDto>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseClientDto>>(clients);
        }

        public async Task<ResponseClientDto> GetByCpfAsync(string cpf)
        {
            var clients = await _clientRepository.GetByCpfAsync(cpf);
            return _mapper.Map<ResponseClientDto>(clients);
        }

        public async Task<ResponseClientDto> CreateAsync(RequestClientDto dto)
        {
            var client = new Client(dto.Name, dto.Cpf, dto.Email);

            await _clientRepository.CreateAsync(client);

            return _mapper.Map<ResponseClientDto>(client); 
        }
    }
}
