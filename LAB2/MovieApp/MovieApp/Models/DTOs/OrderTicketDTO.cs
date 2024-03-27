namespace MovieApp.Models.DTOs
{
    public class OrderTicketDTO
    {
        public List<TicketInOrder>? AllProducts { get; set; }
        public double TotalPrice { get; set; }

    }
}
