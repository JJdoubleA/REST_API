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
        [HttpGet("{email}")]
        public async Task<ActionResult<bool>> GetCustomer(string email)
        {
           var customers = await _context.customers.Where(customer => customer.email_of_company_contact == email).ToListAsync();
            if(!CustomersExists(email))
            {
                return false;
            }
            return true;
        }

        // We will add the endpoint above that looks into our Mysql DB to see if the email from there matches the one a User may have tried to register with \\
        private bool CustomersExists(string email)
        {
            return _context.customers.Any(e => e.email_of_company_contact == email);
        }
    }
}
