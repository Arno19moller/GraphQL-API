using GraphQL.Data;
using GraphQL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly SakilaContext _context;

        public ActorController(SakilaContext context)
        {
            _context = context;
        }

        // GET: api/Actor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            try
            {
                var actors = await _context.Actors.Take(2).ToListAsync();
                return Ok(actors);
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        // GET: api/Actor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var actor = await _context.Actors.FindAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }
    }
}
