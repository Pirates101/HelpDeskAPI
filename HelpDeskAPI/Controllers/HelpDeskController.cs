using HelpDeskAPI.Models;
using HelpDeskAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelpDeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpDeskController : ControllerBase
    {
        private readonly HelpDeskContext _helpDeskcontext;

        public HelpDeskController(HelpDeskContext helpDeskContext)
        {
            _helpDeskcontext = helpDeskContext;
        }

        // GET: api/<HelpDeskController>
        [HttpGet]
        public IActionResult Get()
        
        {
            var response = _helpDeskcontext.Tickets.ToList();
            return Ok(response);
        }

        // GET api/<HelpDeskController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {

            var ticket = _helpDeskcontext.Tickets.Find(id);
            return ticket != null
                ? Ok(ticket)
                : NotFound();
        }

        // POST api/<HelpDeskController>
        [HttpPost]
        public IActionResult Post([FromBody] TicketModel value) 
        {
            var ticket = _helpDeskcontext.Tickets.Add(value);
 
            _helpDeskcontext.SaveChanges();

            var id = ticket.Entity.Id;
            return Created($"/api/helpdesk/{id}", value);
        }

        // PUT api/<HelpDeskController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketModel value)
        {
            return Created("/api/[controller]/{id)", value);
        }

        // DELETE api/<HelpDeskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var ticket = _helpDeskcontext.Tickets.Find(id);

            if (ticket != null)
            {
                _helpDeskcontext.Tickets.Remove(ticket);
                _helpDeskcontext.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }
    }
}
