using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ILPManagementSystem.Models;
using ILPManagementSystem.Controllers;
using Moq;
using NUnit.Framework;
using ILPManagementSystem.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ILPManagementSystem.Repository;
namespace ILP360NUnitTest
{
    [TestFixture]
    public class LocationControllerNUnitTests
    {
        private LocationController _controller;
        private Mock<IMapper> _mockMapper;
        private Mock<ILocationRepository> _mockLocationRepository;

        [SetUp]
        public void SetUp()
        {

            _mockMapper = new Mock<IMapper>();
            _mockLocationRepository = new Mock<ILocationRepository>();

            _controller = new LocationController(

                _mockMapper.Object,
                _mockLocationRepository.Object
            );
        }

        [Test]

        public async Task GetAllLocation_ReturnsOkResult_WithListOfLocations()
        {
            // Arrange
            var locations = new List<Location>
            {
                new Location { Id = 1, LocationName = "Location1" },
                new Location { Id = 2, LocationName = "Location2" }
            };

            _mockLocationRepository.Setup(repo => repo.GetAllLocationsAsync()).ReturnsAsync(locations);

            // Act
            var result = await _controller.GetAllLocation();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<Location>>());
            Assert.That(okResult.Value, Is.EqualTo(locations));
        }

        [Test]
        public async Task AddNewLocation_ReturnsOkResult_WhenLocationIsAdded()
        {
            // Arrange
            var location = new Location { Id = 1, LocationName = "New Location" };

            _mockLocationRepository.Setup(repo => repo.AddNewLocation(location)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddNewLocation(location);

            // Assert
            Assert.That(result, Is.InstanceOf<OkResult>());
        }

    }
}





