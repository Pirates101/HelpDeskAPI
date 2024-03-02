using HelpDeskAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskAPI.Services
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<TicketModel> Tickets { get; set; }

        public DbSet<BookmarkedTicketModel> FavoriteTickets { get; set; }
    }
}
