using NadTechWebAPI.Data;
using NadTechWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace NadTechWebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private static ICollection<Customer> Customers = CustomerData.Customers;

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(Customers);
        }
        
        [HttpGet]
        public IHttpActionResult Get(int Id)
        {
            var customer = Customers.FirstOrDefault(d => d.CustomerId == Id);
            if (customer != null)
                return Ok(customer);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult Find(string Name)
        {
            var customer = Customers.FirstOrDefault(d => d.Name == Name);
            if (customer != null)
                return Ok(customer);
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Customer");

            Customers.Add(customer);
            return Created($"/api/customer/{customer.CustomerId}", customer);
            //return CreatedAtRoute("Get", new { Id = customer.CustomerId }, customer);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var customer = Customers.FirstOrDefault(d => d.CustomerId == Id);
            if (customer != null)
            {
                Customers.Remove(customer);
                return Ok();
            }
            return NotFound();
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Customer");

            var existingCustomer = Customers.FirstOrDefault(d => d.CustomerId == customer.CustomerId);

            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Age = customer.Age;
                existingCustomer.Gender = customer.Gender;
                existingCustomer.Address = customer.Address;
                existingCustomer.Orders = customer.Orders;
                return Ok();
            }
            else
            {
                Customers.Add(customer);
                return Created($"/api/customer/{customer.CustomerId}", customer);
                //return CreatedAtRoute("Get", new { Id = customer.CustomerId }, customer);
            }
        }
    }
}
