using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using ILPManagementSystem.Controllers;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILPManagementSystem.Repository.IRepository;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Tests
{
    [TestFixture]
    public class BatchProgramControllerTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IBatchProgramRepository> _repositoryMock;
        private BatchProgramController _controller;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IBatchProgramRepository>();
            _controller = new BatchProgramController(_mapperMock.Object, _repositoryMock.Object);
        }

        [Test]
        public async Task Get_ReturnsOkResult_WithBatchPrograms()
        {
            // Arrange
            var batchPrograms = new List<BatchProgram> { new BatchProgram(), new BatchProgram() };
            _repositoryMock.Setup(r => r.GetBatchProgramsAsync()).ReturnsAsync(batchPrograms);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(batchPrograms));
        }

        [Test]
        public async Task GetBatchList_ReturnsOkResult_WithBatchPrograms()
        {
            // Arrange
            var batchPrograms = new List<BatchProgram> { new BatchProgram(), new BatchProgram() };
            _repositoryMock.Setup(r => r.GetBatchProgramsWithBatchsAsync()).ReturnsAsync(batchPrograms);

            // Act
            var result = await _controller.GetBatchList();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(batchPrograms));
        }

        [Test]
        public async Task GetById_ReturnsOkResult_WithBatchProgram()
        {
            // Arrange
            var batchProgram = new BatchProgram();
            _repositoryMock.Setup(r => r.GetBatchProgramsAsync(1)).ReturnsAsync(batchProgram);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(batchProgram));
        }

        [Test]
        public async Task GetBatchCount_ReturnsOkResult_WithCount()
        {
            // Arrange
            var count = 5;
            _repositoryMock.Setup(r => r.GetBatchCount(1)).ReturnsAsync(count);

            // Act
            var result = await _controller.GetBatchCount(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(count));
        }
        [Test]

        public async Task Get_ReturnsEmptyList_WhenNoBatchPrograms()
        {
            // Arrange
            var batchPrograms = new List<BatchProgram>();
            _repositoryMock.Setup(r => r.GetBatchProgramsAsync()).ReturnsAsync(batchPrograms);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(batchPrograms));
        }



    }
}


