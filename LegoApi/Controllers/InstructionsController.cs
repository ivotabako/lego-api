using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LegoApi.Data;
using LegoApi.Models;
using Microsoft.Extensions.Logging;

namespace LegoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly LegoApiContext _context;
        private readonly ILogger _logger;
        public InstructionsController(LegoApiContext context, ILoggerFactory logger)
        {
            _context = context;

            _logger = logger.CreateLogger(nameof(SetsController));
        }

        // GET: api/LegoSetInstructionsPages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegoSetInstructionsPage>>> GetLegoSetInstructionsPages([FromQuery] int number = 0, int pageNumber = 0)
        {
            if (number == 0)
            {
                return BadRequest("please provide lego number!");
            }
            return await _context.LegoSetInstructionsPages
                .Where(p => p.LegoSet.IdNumber.Equals(number))
                .Where(p => pageNumber == 0 || p.PageNumber == pageNumber)
                .OrderBy(p=>p.PageNumber).ToListAsync();
        }

        // GET: api/LegoSetInstructionsPages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegoSetInstructionsPage>> GetLegoSetInstructionsPage(Guid id)
        {
            var legoSetInstructionsPage = await _context.LegoSetInstructionsPages.FindAsync(id);

            if (legoSetInstructionsPage == null)
            {
                _logger.LogInformation($"lego instructions with id {id} were not found");
                return NotFound();
            }

            return legoSetInstructionsPage;
        }

        // PUT: api/LegoSetInstructionsPages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegoSetInstructionsPage(Guid id, LegoSetInstructionsPage legoSetInstructionsPage)
        {
            if (id != legoSetInstructionsPage.Id)
            {
                return BadRequest();
            }

            _context.Entry(legoSetInstructionsPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegoSetInstructionsPageExists(id))
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

        // POST: api/LegoSetInstructionsPages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LegoSetInstructionsPage>> PostLegoSetInstructionsPage(LegoSetInstructionsPage legoSetInstructionsPage)
        {
            _context.LegoSetInstructionsPages.Add(legoSetInstructionsPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLegoSetInstructionsPage", new { id = legoSetInstructionsPage.Id }, legoSetInstructionsPage);
        }

        // DELETE: api/LegoSetInstructionsPages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LegoSetInstructionsPage>> DeleteLegoSetInstructionsPage(Guid id)
        {
            var legoSetInstructionsPage = await _context.LegoSetInstructionsPages.FindAsync(id);
            if (legoSetInstructionsPage == null)
            {
                return NotFound();
            }

            _context.LegoSetInstructionsPages.Remove(legoSetInstructionsPage);
            await _context.SaveChangesAsync();

            return legoSetInstructionsPage;
        }

        private bool LegoSetInstructionsPageExists(Guid id)
        {
            return _context.LegoSetInstructionsPages.Any(e => e.Id == id);
        }
    }
}
