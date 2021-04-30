using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ElevatorController : ControllerBase
  {
    private readonly RestAPIContext _context;

    public ElevatorController(RestAPIContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Elevator>>> GetElevator()
    {
      return await _context.elevators.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Elevator>> GetElevator(long id)
    {
      var elevator = await _context.elevators.FindAsync(id);

      if (elevator == null)
      {
        return NotFound();
      }

      return elevator;
    }

    [HttpGet("{id}/status")]
    public async Task<ActionResult<string>> GetElevatortatus(long id)
    {
      var elevator = await _context.elevators.FindAsync(id);

      if (elevator == null)
      {
        return NotFound();
      }

      return elevator.status;
    }

    [HttpGet("inactive")]
    public async Task<ActionResult<List<Elevator>>> InactiveElevator()
    {
      var elevator = await _context.elevators
          .Where(elevator => elevator.status != "Active")
          .ToListAsync();

      return elevator;
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> ChangeElevatortatus(long id, [FromBody] Elevator elevator)
    {
      var findElevator = await _context.elevators.FindAsync(id);

      if (elevator == null)
      {
        return BadRequest();
      }

      if (findElevator == null)
      {
        return NotFound();
      }

      if (elevator.status == findElevator.status)
      {
        ModelState.AddModelError("status", "Looks like you didn't change the status.");
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      findElevator.status = elevator.status;

      try
      {
        await _context.SaveChangesAsync();
        
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ElevatorExists(id))
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

    private bool ElevatorExists(long id)
    {
      return _context.elevators.Any(e => e.id == id);
    }
  }
}