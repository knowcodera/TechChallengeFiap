namespace Application.Dtos
{
    public class ResponseCategoryDto
    {
        public string Name { get; set; }
        public ICollection<ResponseProductDto> Products { get; set; }
    }
}
