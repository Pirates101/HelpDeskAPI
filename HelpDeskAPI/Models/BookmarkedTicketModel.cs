namespace HelpDeskAPI.Models
{
    public class BookmarkedTicketModel
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string BookmarkedBy { get; set; }
        public DateTime BookmarkedDate { get; set; }
    }
}
