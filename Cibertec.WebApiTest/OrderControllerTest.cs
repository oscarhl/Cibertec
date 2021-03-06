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
    public class OrderControllerTest
    {
        private OrderController _orderController;

        public OrderControllerTest()
        {
            _orderController = new OrderController(
                new NorthwindUniOftWork(ConfigSettings.NorthwindConnectionString)
                );

        }


        [Fact]
        public void Test_Get_All()
        {
            var result = _orderController.GetList() as OkObjectResult;

            Assert.True(result != null);
            Assert.True(result.Value != null);

            var model=result.Value as List<Customer>;
            Assert.True(model.Count > 0);
        }

        [Fact]
        public void Test_Get_All_FluentAssertions()
        {
            var result = _orderController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Customer>;
            model.Count.Should().BeGreaterThan(0);
        }
    }
}
