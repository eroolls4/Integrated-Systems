namespace MovieApp.Models.DTOs
{
    public class AddToOrderDTO
    {
        public Guid SelectedTicketId { get; set; }
        public int Quantity { get; set; }

    }
}
