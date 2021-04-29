using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public InterventionsController(RestAPIContext context)
        {
            _context = context;
        }

        //---------------------------------------Selects All Interventions------------------------------------------\\

        // GET: api/Interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> Getinterventions()
        {
            return await _context.interventions.ToListAsync();
        }

        //---------------------------------------Selects One Intervention---------------------------------------------\\

        // GET: api/Interventions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> GetIntervention(long id)
        {
            var intervention = await _context.interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }


        //---------------------------------------GET INTERVENTION---------------------------------------------\\

        // GET: api/Interventions/pending
        [HttpGet("pending")]
        public async Task<ActionResult<List<Intervention>>> GetPendingIntervention()
        {
            var allInterventions = await _context.interventions.Where(l => l.start_of_intervention == null).ToListAsync();
            var newInterventions = allInterventions.Where(e => e.status == "Pending").ToList();
            return newInterventions;
        }


        //---------------------------------------PUT #1 INTERVENTION---------------------------------------------\\

        // PUT: api/Interventions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/Inprogress")]
        public async Task<IActionResult> PutIntervention(long id, Intervention intervention)
        {
            if (id != intervention.id)
            {
                return BadRequest();
            }

            Intervention interventionFound = await _context.interventions.FindAsync(id);
            interventionFound.status = intervention.status;
            interventionFound.start_of_intervention = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
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

        //---------------------------------------PUT #2 INTERVENTION---------------------------------------------\\

        // PUT: api/Interventions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPut("{id}/completed")]
        public async Task<IActionResult> PutIntervention2(long id, Intervention intervention)
        {
            if (id != intervention.id)
            {
                return BadRequest();
            }

            Intervention interventionFound = await _context.interventions.FindAsync(id);
            interventionFound.status = intervention.status;
            interventionFound.end_of_intervention = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
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


        // POST: api/Interventions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Intervention>> PostIntervention(Intervention intervention)
        // {
        //     _context.interventions.Add(intervention);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetIntervention", new { id = intervention.id }, intervention);
        // }

        // DELETE: api/Interventions/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteIntervention(long id)
        // {
        //     var intervention = await _context.interventions.FindAsync(id);
        //     if (intervention == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.interventions.Remove(intervention);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool InterventionExists(long id)
        {
            return _context.interventions.Any(e => e.id == id);
        }
    }
    
}
