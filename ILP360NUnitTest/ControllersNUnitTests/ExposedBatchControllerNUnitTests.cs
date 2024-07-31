using ILPManagementSystem.Controllers;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Sprache;
using System.Net;

namespace ILP360NUnitTest
{
    [TestFixture]
    public class ExposedBatchControllerNUnitTests
    {
        private Mock<IExposedBatchRepository> _repositoryMock;
        private ExposedBatchController _controller;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IExposedBatchRepository>();
            _controller = new ExposedBatchController(_repositoryMock.Object);
        }

        //1
        [Test]
        public async Task GetAllBatches_ReturnsOkResultWithListOfAllBatches_ChecksNotNull()
        {
            // Arrange
            var mockBatches = new List<ExposedBatchDTO>
            {
                new ExposedBatchDTO { Id = 1, BatchName = "ILP2324-03" },
                new ExposedBatchDTO { Id = 2, BatchName = "ILP2324-04" }
            };

            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockBatches);

            // Act
            var result = await _controller.GetAllBatches();

            // Assert
            Assert.That(result, Is.Not.Null, "Expected OkObjectResult");
        }
        //2
        [Test]
        public async Task GetAllBatches_ReturnsOkResultWithBatches_CheckWhetherStatusCodeIs200()
        {
            // Arrange
            var mockBatches = new List<ExposedBatchDTO>
            {
                new ExposedBatchDTO { Id = 1, BatchName = "ILP2324-03" },
                new ExposedBatchDTO { Id = 2, BatchName = "ILP2324-04" }
            };

            // Setup the mock repository to return the mock data
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockBatches);

            // Act
            var result = await _controller.GetAllBatches();

            // Assert
            var okResult = result.Result as OkObjectResult;

            // Ensure the status code is 200
            Assert.That(okResult.StatusCode, Is.EqualTo(200), "Expected status code 200");

        }
        //3
        [Test]
        public async Task GetAllBatches_ReturnsOkResultWithBatches_CheckWhetherIsSuccessIsTrue()
        {
            // Arrange
            var mockBatches = new List<ExposedBatchDTO>
            {
                new ExposedBatchDTO { Id = 1, BatchName = "ILP2324-03" },
                new ExposedBatchDTO { Id = 2, BatchName = "ILP2324-04" }
            };

            // Setup the mock repository to return the mock data
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockBatches);

            // Act
            var result = await _controller.GetAllBatches();
            var okResult = result.Result as OkObjectResult;

            var expectedResponse = new APIResponse
            {
                IsSuccess = true,
                Result = mockBatches,
                StatusCode = HttpStatusCode.OK
            };
            var actualResponse = okResult.Value as APIResponse;

            // Assert
            ClassicAssert.AreEqual(expectedResponse.IsSuccess, actualResponse.IsSuccess);
        }
        //4
        [Test]
        public async Task GetAllBatches_ReturnsOkResultWithBatches_CheckWhetherTheResultIsInExpectedFormat()
        {
            // Arrange
            var mockBatches = new List<ExposedBatchDTO>
            {
                new ExposedBatchDTO { Id = 1, BatchName = "ILP2324-03" },
                new ExposedBatchDTO { Id = 2, BatchName = "ILP2324-04" }
            };

            // Setup the mock repository to return the mock data
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockBatches);

            // Act
            var result = await _controller.GetAllBatches();
            var okResult = result.Result as OkObjectResult;

            var expectedResponse = new APIResponse
            {
                IsSuccess = true,
                Result = mockBatches,
                StatusCode = HttpStatusCode.OK
            };
            var actualResponse = okResult.Value as APIResponse;

            // Assert
            ClassicAssert.AreEqual(expectedResponse.Result, actualResponse.Result);
        }


    }
}