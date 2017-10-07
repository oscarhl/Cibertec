using Cibertec.Models;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.WebApi.Controllers;
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

        public CustomerControllerTests()
        {
            _customerController = new CustomerController(
                new NorthwindUniOftWork(ConfigSettings.NorthwindConnectionString)
                );

        }


        [Fact]
        public void Test_Get_All()
        {
            var result = _customerController.GetList() as OkObjectResult;

            Assert.True(result != null);
            Assert.True(result.Value != null);

            var model=result.Value as List<Customer>;
            Assert.True(model.Count > 0);
        }

        [Fact]
        public void Test_Get_All_FluentAssertions()
        {
            var result = _customerController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Customer>;
            model.Count.Should().BeGreaterThan(0);
        }
    }
}
