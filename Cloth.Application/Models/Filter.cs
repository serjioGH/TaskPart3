namespace Cloth.Application.Models
{
    public class Filter
    {
        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public List<string> Sizes { get; set; } = new List<string>();
        public List<string> CommonWords { get; set; } = new List<string>();
    }
}
