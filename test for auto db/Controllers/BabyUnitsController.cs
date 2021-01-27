using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BabyUnitsEksamenA;
using test_for_auto_db;

namespace test_for_auto_db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyUnitsController : ControllerBase
    {
        private readonly BabyUnitsContext _context;

        public BabyUnitsController(BabyUnitsContext context)
        {
            _context = context;
        }

        // GET: api/BabyUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BabyUnit>>> GetbabyUnits()
        {
            return await _context.babyUnits.ToListAsync();
        }

        // GET: api/BabyUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BabyUnit>> GetBabyUnit(int id)
        {
            var babyUnit = await _context.babyUnits.FindAsync(id);

            if (babyUnit == null)
            {
                return NotFound();
            }

            return babyUnit;
        }

        // PUT: api/BabyUnits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBabyUnit(int id, BabyUnit babyUnit)
        {
            if (id != babyUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(babyUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BabyUnitExists(id))
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

        // POST: api/BabyUnits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BabyUnit>> PostBabyUnit(BabyUnit babyUnit)
        {
            _context.babyUnits.Add(babyUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBabyUnit", new { id = babyUnit.Id }, babyUnit);
        }

        // DELETE: api/BabyUnits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BabyUnit>> DeleteBabyUnit(int id)
        {
            var babyUnit = await _context.babyUnits.FindAsync(id);
            if (babyUnit == null)
            {
                return NotFound();
            }

            _context.babyUnits.Remove(babyUnit);
            await _context.SaveChangesAsync();

            return babyUnit;
        }

        private bool BabyUnitExists(int id)
        {
            return _context.babyUnits.Any(e => e.Id == id);
        }
    }
}
