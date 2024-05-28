namespace Application.Dtos
{
    public class ResponseCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ResponseProductDto> Products { get; set; }
    }
}
