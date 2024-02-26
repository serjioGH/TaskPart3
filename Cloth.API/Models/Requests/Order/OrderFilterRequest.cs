namespace Cloth.API.Models.Requests.Order
{
    public class OrderFilterRequest
    {
        public DateTime? MinDate { get; set; }

        public DateTime? MaxDate { get; set; }

        public Guid UserId { get; set; }

        public Guid StatusId { get; set; }
    }
}