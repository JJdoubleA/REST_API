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

    public class EmployeesController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public EmployeesController(RestAPIContext context)
        {
            _context = context;
        }

        //-----------------------------------------------------------------------------------------\\

        //GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> CheckIfEmployees()
        {
            return await _context.employees.ToListAsync();
        }

        //-----------------------------------------------------------------------------------------\\

        //GET: api/Employees/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployees(long id)
        {
            var employees = await _context.employees.FindAsync(id);

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        //-----------------------------------------------------------------------------------------\\

        // GET: api/Employees/valid/{email}
        [HttpGet("valid/{email}")]
        public async Task<ActionResult<bool>> CheckIfEmployees(string email)
        {
            var employees = await _context.employees.Where(employees => employees.email == email).ToListAsync();
            var isValid = false;

            foreach (Employee employee in employees)
            {
                if (employee.email == email)
                {
                    isValid = true;
                }
            }

            return isValid;
        }



        //-----------------------------------------------------------------------------------------\\

        private bool EmployeesExists(string email)
        {
            return _context.employees.Any(e => e.email == email);
        }
    }
}