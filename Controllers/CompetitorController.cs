using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pratik_Survivor.Data;
using System;

namespace Pratik_Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly UygulamaDbContext _context;

        public CompetitorController(UygulamaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competitor>>> GetCompetitors()
        {
            return await _context.Competitors.Include(c => c.Category).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Competitor>> GetCompetitor(int id)
        {
            var competitor = await _context.Competitors.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
            if (competitor == null)
            {
                return NotFound();
            }

            return competitor;
        }

        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Competitor>>> GetCompetitorsByCategory(int categoryId)
        {
            var competitors = await _context.Competitors.Include(c => c.Category)
                .Where(c => c.CategoryId == categoryId).ToListAsync();
            return Ok(competitors);
        }

        [HttpPost]
        public async Task<ActionResult<Competitor>> PostCompetitor(Competitor competitor)
        {
            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCompetitor", new { id = competitor.Id }, competitor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetitor(int id, Competitor competitor)
        {
            if (id != competitor.Id)
            {
                return BadRequest();
            }

            _context.Entry(competitor).State = EntityState.Modified;
            competitor.ModifiedDate = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
            {
                return NotFound();
            }

            _context.Competitors.Remove(competitor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CompetitorExists(int id)
        {
            return _context.Competitors.Any(e => e.Id == id);
        }
    }

}
