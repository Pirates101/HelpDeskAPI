namespace HelpDeskAPI.Models
{
    public class BookmarkedTicketModel
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string MarkedBy { get; set; }
        public DateTime MarkedDate { get; set; }
    }
}
