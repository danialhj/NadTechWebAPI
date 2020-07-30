using NadTechWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace NadTechWebAPI.Data
{
    public static class CustomerData
    {
        public static ICollection<Customer> Customers = new List<Customer>{
            new Customer
            {
                CustomerId = 1,
                Name = "John",
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
            },
            new Customer
            {
                CustomerId = 2,
                Name = "Doe",
                Age = DateTime.Parse("1982-02-02"),
                Gender = Models.Enums.Gender.Male,
                Address = new Address
                {
                    Street = "XYZ Street",
                    Postcode = "2020",
                    HouseNumber = 21
                },
                Orders = new List<Order>
                {
                    new Order
                    {
                        OrderId = "Order321",
                        OrderDate = DateTime.Parse("2020-03-01"),
                        Amount = 200
                    },
                    new Order
                    {
                        OrderId = "Order234",
                        OrderDate = DateTime.Parse("2020-05-04"),
                        Amount = 140
                    }
                }
            },
            new Customer
            {
                CustomerId = 3,
                Name = "Liza",
                Age = DateTime.Parse("1994-02-03"),
                Gender = Models.Enums.Gender.Female,
                Address = new Address
                {
                    Street = "AA Street",
                    Postcode = "3030",
                    HouseNumber = 29
                },
                Orders = new List<Order>
                {
                    new Order
                    {
                        OrderId = "Order1122",
                        OrderDate = DateTime.Parse("2020-06-06"),
                        Amount = 200
                    },
                    new Order
                    {
                        OrderId = "Order2233",
                        OrderDate = DateTime.Parse("2020-07-07"),
                        Amount = 140
                    }
                }
            },
            new Customer
            {
                CustomerId = 4,
                Name = "Katherine",
                Age = DateTime.Parse("1999-03-03"),
                Gender = Models.Enums.Gender.Female,
                Address = new Address
                {
                    Street = "BB Street",
                    Postcode = "4114",
                    HouseNumber = 65
                },
                Orders = new List<Order>
                {
                    new Order
                    {
                        OrderId = "Order456",
                        OrderDate = DateTime.Parse("2020-01-04"),
                        Amount = 120
                    },
                    new Order
                    {
                        OrderId = "Order234",
                        OrderDate = DateTime.Parse("2020-02-04"),
                        Amount = 140
                    }
                }
            },
        };
    }
}