namespace HelpDeskAPI.Models
{
    public class TicketModel
    {

            public int Id { get; set; }
            public int Ticket { get; set; }
            public string Issue { get; set; }
            public string OpenedBy { get; set; }
            public DateTime Date { get; set; }
            public bool Status { get; set; }
            public string ResolvedBy { get; set; }
            public string Resolution { get; set; }


    }
}
