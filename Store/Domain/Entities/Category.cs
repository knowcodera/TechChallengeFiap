namespace Domain.Entities
{
    public class Category
    {

        public Category()
        {

        }
        public Category(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public ICollection<Product> Products { get; private set; }
    }
}
