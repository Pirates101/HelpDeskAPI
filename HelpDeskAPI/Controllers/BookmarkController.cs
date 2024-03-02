using HelpDeskAPI.Models;
using HelpDeskAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelpDeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly HelpDeskContext _helpDeskcontext;

        public BookmarkController(HelpDeskContext helpDeskContext)
        {
            _helpDeskcontext = helpDeskContext;
        }

        // GET: api/<BookmarkController>
        [HttpGet]
        public IActionResult Get()
        {
            var response = _helpDeskcontext.FavoriteTickets.ToList();
            return Ok(response);
        }

        // GET api/<BookmarkController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {

            var ticket = _helpDeskcontext.FavoriteTickets.Find(id);
            return ticket != null
                ? Ok(ticket)
                : NotFound();
        }

        // POST api/<BookmarkController>
        [HttpPost]
        public IActionResult Post([FromBody] BookmarkedTicketModel value)
        {
            var ticket = _helpDeskcontext.FavoriteTickets.Add(value);

            _helpDeskcontext.SaveChanges();

            var id = ticket.Entity.Id;
            return Created($"/api/helpdesk/{id}", value);
        }

        // PUT api/<BookmarkController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookmarkedTicketModel value)
        {
            return Created("/api/[controller]/{id)", value);
        }

        // DELETE api/<BookmarkController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var ticket = _helpDeskcontext.FavoriteTickets.Find(id);

            if (ticket != null)
            {
                _helpDeskcontext.FavoriteTickets.Remove(ticket);
                _helpDeskcontext.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }
    }
}
