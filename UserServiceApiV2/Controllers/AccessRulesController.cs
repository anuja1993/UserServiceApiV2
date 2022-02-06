#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserServiceApiV2.Data;
using UserServiceApiV2.Entities;

namespace UserServiceApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessRulesController : ControllerBase
    {
        private readonly DataContext _context;

        public AccessRulesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AccessRules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessRule>>> GetAccessRules()
        {
            return await _context.AccessRules.ToListAsync();
        }

        // GET: api/AccessRules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccessRule>> GetAccessRule(int id)
        {
            var accessRule = await _context.AccessRules.FindAsync(id);

            if (accessRule == null)
            {
                return NotFound();
            }

            return accessRule;
        }

        // PUT: api/AccessRules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccessRule(int id, AccessRule accessRule)
        {
            if (id != accessRule.Id)
            {
                return BadRequest();
            }

            _context.Entry(accessRule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessRuleExists(id))
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

        // POST: api/AccessRules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccessRule>> PostAccessRule(AccessRule accessRule)
        {
            _context.AccessRules.Add(accessRule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccessRule", new { id = accessRule.Id }, accessRule);
        }

        // DELETE: api/AccessRules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessRule(int id)
        {
            var accessRule = await _context.AccessRules.FindAsync(id);
            if (accessRule == null)
            {
                return NotFound();
            }

            _context.AccessRules.Remove(accessRule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccessRuleExists(int id)
        {
            return _context.AccessRules.Any(e => e.Id == id);
        }
    }
}
