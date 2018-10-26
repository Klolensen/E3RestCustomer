using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using E3RestService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E3RestService.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private static List<Customer> _customerList = new List<Customer>()
        {
            new Customer(1, "John", "Doe", 2018),
            new Customer(2, "Jane", "Doe", 2018),
            new Customer(3, "James", "Smith", 2018)
        };

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerList;
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            foreach (Customer customer in _customerList)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            throw new FileNotFoundException();
        }
        
        // POST: api/Customers
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            _customerList.Add(customer);
        }
        
        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            _customerList.RemoveAll(customerDelegate => customerDelegate.Id == id);
            _customerList.Add(customer);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerList.RemoveAll(customerDelegate => customerDelegate.Id == id);
        }

        [HttpGet("FindByYear")]
        public IEnumerable<Customer> GetCustomerByName([FromQuery] string year)
        {
            List<Customer> yearCustomersList = new List<Customer>();
            foreach (Customer customer in _customerList)
            {
                if (customer.RegYear == int.Parse(year))
                {
                    yearCustomersList.Add(customer);
                }
            }
            return yearCustomersList;
        }
    }
}
