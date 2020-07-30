using Microsoft.VisualStudio.TestTools.UnitTesting;
using NadTechWebAPI.Controllers;
using NadTechWebAPI.Data;
using NadTechWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace NadTechWebAPI.Controllers.Tests
{
    [TestClass()]
    public class CustomerControllerTests
    {
        [TestMethod()]
        public void Get_ShouldReturnAllCustomers()
        {
            var customers = CustomerData.Customers;
            var controller = new CustomerController();

            var response = controller.Get() as OkNegotiatedContentResult<ICollection<Customer>>;
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(response.Content.Count, customers.Count);
        }

        [TestMethod()]
        public void Get_ShouldReturnCorrectCustomer()
        {
            var testCustomerId = 1;
            var customer = CustomerData.Customers.FirstOrDefault(d=> d.CustomerId == testCustomerId);
            var controller = new CustomerController();

            var response = controller.Get(testCustomerId) as OkNegotiatedContentResult<Customer>;
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(response.Content.Name, customer.Name);
        }

        [TestMethod()]
        public void Find_ShouldReturnCorrectCustomer()
        {
            var testCustomerName = "Doe";
            var customer = CustomerData.Customers.FirstOrDefault(d => d.Name == testCustomerName);
            var controller = new CustomerController();

            var response = controller.Find(testCustomerName) as OkNegotiatedContentResult<Customer>;
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(response.Content.CustomerId, customer.CustomerId);
        }

        [TestMethod()]
        public void Post_ShouldReturnCustomer()
        {
            var newCustomer = new Customer
            {
                CustomerId = 11,
                Name = "Kevin",
                Age = DateTime.Parse("1992-01-01"),
                Gender = Models.Enums.Gender.Male,
                Address = new Address
                {
                    Street = "ABC Street",
                    Postcode = "1010",
                    HouseNumber = 12
                },
                Orders = new List<Order>
                {
                    new Order
                    {
                        OrderId = "Order123",
                        OrderDate = DateTime.Parse("2020-02-03"),
                        Amount = 200
                    },
                    new Order
                    {
                        OrderId = "Order234",
                        OrderDate = DateTime.Parse("2020-08-04"),
                        Amount = 140
                    }
                }
            };
            var controller = new CustomerController();

            var response = controller.Post(newCustomer) as CreatedAtRouteNegotiatedContentResult<Customer>;
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(response.Content.Name, newCustomer.Name);
        }

        [TestMethod()]
        public void Delete_ShouldReturnOKResult()
        {
            var testCustomerId = 4;
            var controller = new CustomerController();

            var response = controller.Delete(testCustomerId);
            Assert.AreEqual(response.GetType(), typeof(OkResult));
        }

        [TestMethod()]
        public void Put_ShouldReturnCustomer()
        {
            var testCustomer = new Customer
            {
                CustomerId = 1,
                Name = "John Wick",
                Age = DateTime.Parse("1992-01-01"),
                Gender = Models.Enums.Gender.Male,
                Address = new Address
                {
                    Street = "ABC Street",
                    Postcode = "1010",
                    HouseNumber = 12
                },
                Orders = new List<Order>
                {
                    new Order
                    {
                        OrderId = "Order123",
                        OrderDate = DateTime.Parse("2020-02-03"),
                        Amount = 200
                    },
                    new Order
                    {
                        OrderId = "Order234",
                        OrderDate = DateTime.Parse("2020-08-04"),
                        Amount = 140
                    }
                }
            };
            var controller = new CustomerController();

            var response = controller.Put(testCustomer);
            Assert.AreEqual(response.GetType(), typeof(OkResult));
        }
    }
}