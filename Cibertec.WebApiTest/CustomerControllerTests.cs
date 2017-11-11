using Cibertec.Models;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using Cibertec.WebApi.Controllers;
using Ciberted.Repository.MoqTest;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cibertec.WebApiTest
{
    public class CustomerControllerTests
    {
        private CustomerController _customerController;
        private readonly IUnitOfWork _unitMocked;

        public CustomerControllerTests()
        {
            //_customerController = new CustomerController(
            //    new NorthwindUniOftWork(ConfigSettings.NorthwindConnectionString)
            //    );

            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstante();
            _customerController = new CustomerController(_unitMocked);
        }
        
        //[Fact]
        //public void Test_Get_All()
        //{
        //    var result = _customerController.GetList() as OkObjectResult;

        //    Assert.True(result != null);
        //    Assert.True(result.Value != null);

        //    var model=result.Value as List<Customer>;
        //    Assert.True(model.Count > 0);
        //}

        //[Fact(DisplayName ="[CustomerController] Get List")]
        //public void Get_All_Test()
        //{
        //    var result = _customerController.GetList() as OkObjectResult;

        //    result.Should().NotBeNull();
        //    result.Value.Should().NotBeNull();

        //    var model = result.Value as List<Customer>;
        //    model.Count.Should().BeGreaterThan(0);
        //}

        [Fact(DisplayName ="[CustomerController] Insert")]
        public void Insert_customer_Test()
        {
            var customer = new Customer
            {
                Id = 101,
                City = "Lima",
                Country = "peru",
                FirstName = "Julio",
                LastName = "Velarde",
                Phone = "99966333"
            };

            var result = _customerController.Post(customer) as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(101);
        }

        [Fact(DisplayName ="[CustomerController] Update")]
        public void Update_Customer_Test()
        {
            var customer = new Customer
            {
                Id = 1,
                City = "Lima",
                Country = "peru",
                FirstName = "Julio",
                LastName = "Velarde",
                Phone = "99966333"
            };

            var result = _customerController.Put(customer) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value?.GetType().GetProperty("Message").GetValue(result.Value);
            model.Should().Be("The customer is update");


            var currentCustomer = _unitMocked.Customers.GetById(1);
            currentCustomer.Should().NotBeNull();
            currentCustomer.Id.Should().Be(customer.Id);
            currentCustomer.City.Should().Be(customer.City);
            currentCustomer.Country.Should().Be(customer.Country);
            currentCustomer.FirstName.Should().Be(customer.FirstName);
            currentCustomer.LastName.Should().Be(customer.LastName);
            currentCustomer.Phone.Should().Be(customer.Phone);


        }
    }
}
