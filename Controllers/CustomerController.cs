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
    public class CustomersController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public CustomersController(RestAPIContext context)
        {
            _context = context;
        }        

        //----------------------------------- Retrieving information from all Customers -----------------------------------\\

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.customers.ToListAsync();
        }
        
        //-----------------------------------  -----------------------------------\\

        // GET: api/Customer/id
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Customer>> GetCustomer(long id)
        // {
        //     var customers = await _context.customers.FindAsync(id);

        //     if (customers == null)
        //     {
        //         return NotFound();
        //     }

        //     return customers;
        // }
        
        //----------------------------------- Matching Users portal-email with Mysql-email -----------------------------------\\

        // GET: api/Customers/1/email
        [HttpGet("getEmail/{email}")]
        public async Task<ActionResult<bool>> GetCustomer(string email)
        {
           var customers = await _context.customers.Where(customer => customer.email_of_company_contact == email).ToListAsync();
            if(!CustomersExists(email))
            {
                return false;
            }
            return true;
        }

        [HttpGet("{id}/building")]
        public async Task<ActionResult<List<Building>>> GetBuilding(long id)
        {
            var building = await _context.buildings.Where(b => b.customer_id == id).ToListAsync();
            
            

            if (building == null)
            {
              
                return NotFound();
            }

            return building;
        }

        [HttpGet("{Email}")]
            public async Task<ActionResult<List<Customer>>> GetBatteryStatus(string Email)
            {
            var Customers = await _context.customers
                .Where(Customer => Customer.email_of_company_contact == Email)
                .ToListAsync();



            if (Customers == null)
            {
                return NotFound();
            }

            return Customers;
        }

         [HttpGet("{id}/battery")]
        public async Task<ActionResult<List<Battery>>> GetBattery(long id)
        {
            var battery = await _context.batteries.Where(b => b.building_id == id).ToListAsync();
            
            

            if (battery == null)
            {
              
                return NotFound();
            }

            return battery;
        }
        [HttpGet("{id}/column")]
        public async Task<ActionResult<List<Column>>> GetColumn(long id)
        {
            var columns = await _context.columns.Where(b => b.battery_id == id).ToListAsync();
            
            

            if (columns == null)
            {
              
                return NotFound();
            }

            return columns;
        }
         [HttpGet("{id}/elevator")]
        public async Task<ActionResult<List<Elevator>>> GetElevator(long id)
        {
            var elevators = await _context.elevators.Where(b => b.column_id == id).ToListAsync();
            
            

            if (elevators == null)
            {
              
                return NotFound();
            }

            return elevators;
        }

        // We will add the endpoint above that looks into our Mysql DB to see if the email from there matches the one a User may have tried to register with \\
        private bool CustomersExists(string email)
        {
            return _context.customers.Any(e => e.email_of_company_contact == email);
        }
    }
}
