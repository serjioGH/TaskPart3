namespace Cloth.Domain.Entities;

public class Cloth
{
    //public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }

    public List<string> Sizes { get; set; }
    public string Description { get; set; }

}

