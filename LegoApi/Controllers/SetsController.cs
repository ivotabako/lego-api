using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LegoApi.Data;
using LegoApi.Models;

namespace LegoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : ControllerBase
    {
        private readonly LegoApiContext _context;

        public SetsController(LegoApiContext context)
        {
            _context = context;
        }

        // GET: api/Sets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegoSet>>> GetLegoSet()
        {
            return await _context.LegoSets.ToListAsync();
        }

        // GET: api/Sets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegoSet>> GetLegoSet(Guid id)
        {
            var legoSet = await _context.LegoSets.FindAsync(id);

            if (legoSet == null)
            {
                return NotFound();
            }

            return legoSet;
        }

        // PUT: api/Sets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegoSet(Guid id, LegoSet legoSet)
        {
            if (id != legoSet.Id)
            {
                return BadRequest();
            }

            _context.Entry(legoSet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegoSetExists(id))
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

        // POST: api/Sets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LegoSet>> PostLegoSet(LegoSet legoSet)
        {
            _context.LegoSets.Add(legoSet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLegoSet", new { id = legoSet.Id }, legoSet);
        }

        // DELETE: api/Sets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LegoSet>> DeleteLegoSet(Guid id)
        {
            var legoSet = await _context.LegoSets.FindAsync(id);
            if (legoSet == null)
            {
                return NotFound();
            }

            _context.LegoSets.Remove(legoSet);
            await _context.SaveChangesAsync();

            return legoSet;
        }

        private bool LegoSetExists(Guid id)
        {
            return _context.LegoSets.Any(e => e.Id == id);
        }
    }
}
