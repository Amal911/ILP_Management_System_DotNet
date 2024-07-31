using AutoMapper;
using ILPManagementSystem.Controllers;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILPManagementSystem.Tests
{
    [TestFixture]
    public class BatchTypeControllerTests
    {
        private Mock<IBatchTypeRepository> _mockBatchTypeRepository;
        private Mock<IMapper> _mockMapper;
        private BatchTypeController _controller;

        [SetUp]
        public void Setup()
        {
            _mockBatchTypeRepository = new Mock<IBatchTypeRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new BatchTypeController(_mockBatchTypeRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetBatchTypes_ReturnsOkResult_WithListOfBatchTypes()
        {
            // Arrange
            var batchTypes = new List<BatchType> { new BatchType { Id = 1, BatchTypeName = "Type1" } };
            _mockBatchTypeRepository.Setup(repo => repo.GetBatchTypeData()).ReturnsAsync(batchTypes);

            // Act
            var result = await _controller.GetBatchTypes();
            var okResult = result.Result as OkObjectResult;

            // Assert
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(batchTypes));
        }

        [Test]
        public async Task GetBatchTypes_ReturnsOkResult_WithEmptyList()
        {
            // Arrange
            var batchTypes = new List<BatchType>();
            _mockBatchTypeRepository.Setup(repo => repo.GetBatchTypeData()).ReturnsAsync(batchTypes);

            // Act
            var result = await _controller.GetBatchTypes();
            var okResult = result.Result as OkObjectResult;

            // Assert
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(batchTypes));
        }

        [Test]
        public async Task AddNewBatchType_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("BatchTypeName", "Required");
            var batchTypeDTO = new BatchTypeDTO();

            // Act
            var result = await _controller.AddNewBatchType(batchTypeDTO);
            var badRequestResult = result as BadRequestObjectResult;

            // Assert
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
        }


        [Test]
        public async Task AddNewBatchType_ReturnsOkResult_WhenBatchTypeIsAdded()
        {
            // Arrange
            var batchTypeDTO = new BatchTypeDTO { BatchTypeName = "NewType" };
            var batchType = new BatchType { Id = 1, BatchTypeName = "NewType" };
            _mockMapper.Setup(mapper => mapper.Map<BatchType>(batchTypeDTO)).Returns(batchType);
            _mockBatchTypeRepository.Setup(repo => repo.AddBatchType(batchType)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddNewBatchType(batchTypeDTO);
            var okResult = result as OkResult;

            // Assert
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public async Task DeleteBatchType_ReturnsOkResult_WhenBatchTypeIsDeleted()
        {
            // Arrange
            int batchTypeId = 1;
            _mockBatchTypeRepository.Setup(repo => repo.DeleteBatchType(batchTypeId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteBatchType(batchTypeId);
            var okResult = result as OkResult;

            // Assert
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }



    }
}