using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Consolidation_REST.Models;

namespace Rocket_Elevators_Consolidation_REST.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    private readonly RailsApp_developmentContext _context;

    public EmployeesController(RailsApp_developmentContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
    {
      return await _context.Employees.ToListAsync();
    }

    
    
    [HttpGet("{Email}")]
    public async Task<ActionResult<List<Employees>>> GetBatteryStatus(string Email)
    {
       var Employees = await _context.Employees
         .Where(Employee => Employee.Email == Email)
        .ToListAsync();
      
        
      
      if (Employees == null)
      {
        return NotFound();
      }

      return Employees;
    }
    
    
       
       
        [HttpGet("{id}/battery")]
        public async Task<ActionResult<List<Batteries>>> GetBattery(long id)
        {
            var battery = await _context.Batteries.Where(b => b.BuildingId == id).ToListAsync();
            
            

            if (battery == null)
            {
              
                return NotFound();
            }

            return battery;
        }
        [HttpGet("{id}/column")]
        public async Task<ActionResult<List<Columns>>> GetColumn(long id)
        {
            var columns = await _context.Columns.Where(b => b.BatteryId == id).ToListAsync();
            
            

            if (columns == null)
            {
              
                return NotFound();
            }

            return columns;
        }
        [HttpGet("{id}/elevator")]
        public async Task<ActionResult<List<Elevators>>> GetElevator(long id)
        {
            var elevators = await _context.Elevators.Where(b => b.ColumnId == id).ToListAsync();
            
            

            if (elevators == null)
            {
              
                return NotFound();
            }

            return elevators;
        }
        


   

    private bool EmployeeExists(string Email)
    {
      return _context.Employees.Any(e => e.Email == Email);
    }
  }
}