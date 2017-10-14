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
        
        [Fact]
        public void Test_Get_All()
        {
            var result = _customerController.GetList() as OkObjectResult;

            Assert.True(result != null);
            Assert.True(result.Value != null);

            var model=result.Value as List<Customer>;
            Assert.True(model.Count > 0);
        }

        [Fact(DisplayName ="[CustomerController] Get List")]
        public void Get_All_Test()
        {
            var result = _customerController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Customer>;
            model.Count.Should().BeGreaterThan(0);
        }
    }
}
