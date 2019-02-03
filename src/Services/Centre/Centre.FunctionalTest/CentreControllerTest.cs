using System;
using Xunit;
using Centre.Api.Controllers;
using Centre.Api.Data;
using Microsoft.EntityFrameworkCore;
using Centre.Api.Models;

namespace Centre.FunctionalTest
{
    public class CentreControllerTest
    {
        [Fact]
        public void Test_Crud()
        {
            var options = new DbContextOptionsBuilder<CentreContext>()
                .UseInMemoryDatabase(databaseName: "InterchangePoc")
                .Options;
            var context = new CentreContext(options);
            var controller = new CentreController(context);

            var centre = new CentreItem
            {
                Id = 1,
                Name = "centre1",
                Address = "india"
            };
            var actionResult = controller.Add(centre);
            
        }
    }
}
