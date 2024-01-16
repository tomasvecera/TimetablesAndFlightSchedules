using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;
using TimetablesAndFlightSchedules.Web.Areas.Admin.Controllers;

namespace TimetablesAndFlightSchedules.Tests.Admin.CityController
{
    public class CityControllerCreateTests
    {
        [Fact]
        public async Task Create_success()
        {
            //Arrange
            DatabaseFake.Cities.Clear();
            Mock<ICityAdminService> cityServiceMock = new Mock<ICityAdminService>();
            cityServiceMock.Setup(cityService => cityService.Create(It.IsAny<City>()))
                                        .Returns<City>(city => Task.Run(() => { DatabaseFake.Cities.Add(city); }));

            var city = GetCity();
            
            var cityController = new Web.Areas.Admin.Controllers.CityController(cityServiceMock.Object);


            //Act
            var actionResult = await cityController.Create(city);


            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.NotNull(redirectToActionResult.ActionName);
            Assert.Equal(nameof(Web.Areas.Admin.Controllers.CityController.Index), redirectToActionResult.ActionName);

            Assert.NotEmpty(DatabaseFake.Cities);
            Assert.Single(DatabaseFake.Cities);

            Assert.Equal(DatabaseFake.Cities[0].Id, city.Id);
            Assert.Equal(DatabaseFake.Cities[0].Name, city.Name);
        }

        City GetCity()
        {
            return new City()
            {
                Id = 1,
                Name = "Olomouc",
            };
        }
    }
}