using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class RequestClientDto
    {
        public string Name { get; set; }
      
        public string Cpf { get; set; }

        public string Email { get; set; }
    }
}
