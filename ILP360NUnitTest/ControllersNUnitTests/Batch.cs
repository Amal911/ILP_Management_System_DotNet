using AutoMapper;
using ILPManagementSystem.Controllers;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILPManagementSystem.Repository.IRepository;

namespace ILP360NUnitTest
{
    [TestFixture]
    public class BatchControllerNUnitTests
    {

        private BatchController _controller;

        private Mock<IMapper> _mockMapper;
        private Mock<IBatchRepository> _mockBatchRepository;
        private Mock<ICreateBatchService> _mockBatchService;

        [SetUp]
        public void Setup()
        {

            _mockMapper = new Mock<IMapper>();
            _mockBatchRepository = new Mock<IBatchRepository>();
            _mockBatchService = new Mock<ICreateBatchService>();

            _controller = new BatchController(

                _mockMapper.Object,
                _mockBatchRepository.Object,
                _mockBatchService.Object
            );
        }
        [Test]
        public async Task GetAllBatch_ReturnsOkResult_WithListOfBatches()
        {
            // Arrange
            var batches = new List<Batch>
            {
                new Batch { Id = 1, BatchName = "Batch 1", BatchCode = "B001", BatchTypeId = 1, BatchType = new BatchType { Id = 1, BatchTypeName = "Technical" }, BatchDuration = 30, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), IsActive = true, ProgramId = 1, LocationId = 1, Location = new Location { Id = 1, LocationName = "Location1" } },
                new Batch { Id = 2, BatchName = "Batch 2", BatchCode = "B002", BatchTypeId = 2, BatchType = new BatchType { Id = 2, BatchTypeName = "BA" }, BatchDuration = 45, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(45), IsActive = true, ProgramId = 1, LocationId = 2, Location = new Location { Id = 2, LocationName = "Location2" } }
            };

            _mockBatchRepository.Setup(repo => repo.GetBatches()).ReturnsAsync(batches);

            // Act
            var result = await _controller.GetAllBatch();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<Batch>>());
            Assert.That(okResult.Value, Is.EqualTo(batches));
        }


        [Test]
        public async Task GetAllBatchDetails_ReturnsOkResult_WithListOfBatchDTOs()
        {
            // Arrange
            var batchDTOs = new List<BatchDTO>
                             {
                                 new BatchDTO { Id = 1, BatchName = "Batch 1", BatchCode = "B001", batchTypeId = 1, BatchType = "Type1", BatchDuration = 30, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), IsActive = true, ProgramId = 1, LocationId = 1, LocationName = "Location1" },
                                 new BatchDTO { Id = 2, BatchName = "Batch 2", BatchCode = "B002", batchTypeId = 2, BatchType = "Type2", BatchDuration = 45, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(45), IsActive = true, ProgramId = 1, LocationId = 2, LocationName = "Location2" }
                             };
            _mockBatchRepository.Setup(repo => repo.GetDetailedBatchData()).ReturnsAsync(batchDTOs);

            // Act
            var result = await _controller.GetAllBatchDetails();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<BatchDTO>>());
            Assert.That(okResult.Value, Is.EqualTo(batchDTOs));
        }

        [Test]
        public async Task GetBatchDetailById_ReturnsOkResult_WithBatchDTO_WhenBatchExists()
        {
            // Arrange
            int id = 1;
            var batchDTO = new BatchDTO { Id = id, BatchName = "Batch 1", BatchCode = "B001", batchTypeId = 1, BatchType = "Type1", BatchDuration = 30, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), IsActive = true, ProgramId = 1, LocationId = 1, LocationName = "Location1" };
            _mockBatchRepository.Setup(repo => repo.GetBatchDetailById(id)).ReturnsAsync(new[] { batchDTO }); // Return an array

            // Act
            var result = await _controller.GetBatchDetailById(id);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<BatchDTO[]>()); // Expect an array
            var batchDTOs = okResult.Value as BatchDTO[];
            Assert.That(batchDTOs, Contains.Item(batchDTO)); // Check if the array contains the expected item
        }


        [Test]
        public async Task GetBatchDetailById_ReturnsBadRequest_WhenBatchDoesNotExist()
        {
            // Arrange
            int id = 1;
            _mockBatchRepository.Setup(repo => repo.GetBatchDetailById(id)).ReturnsAsync(Enumerable.Empty<BatchDTO>());

            // Act
            var result = await _controller.GetBatchDetailById(id);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.That(badRequestResult.Value, Is.EqualTo("Id not found"));
        }



        [Test]
        public async Task GetBatchByProgram_ReturnsOkResult_WithListOfBatches()
        {
            // Arrange
            int programId = 1;
            var batchList = new List<object>
                        {
                            new { Id = 1, BatchName = "Batch 1", BatchCode = "B001", batchTypeId = 1, BatchType = "Type1", BatchDuration = 30, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), IsActive = true, ProgramId = programId, LocationId = 1, LocationName = "Location1" },
                            new { Id = 2, BatchName = "Batch 2", BatchCode = "B002", batchTypeId = 2, BatchType = "Type2", BatchDuration = 45, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(45), IsActive = true, ProgramId = programId, LocationId = 2, LocationName = "Location2" }
                        };
            _mockBatchRepository.Setup(repo => repo.GetBatchByProgram(programId)).ReturnsAsync(batchList);

            // Act
            var result = await _controller.GetBatchByProgram(programId);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<object>>());
            Assert.That(okResult.Value, Is.EqualTo(batchList));
        }

        [Test]
        public async Task GetTraineeList_ReturnsOkResult_WithTraineeList()
        {
            // Arrange
            int batchId = 1;
            var traineeList = new List<object>
                        {
                            new { Id = 1, Name = "Trainee 1" },
                            new { Id = 2, Name = "Trainee 2" }
                        };
            _mockBatchRepository.Setup(repo => repo.GetBatchTraineeList(batchId)).ReturnsAsync(traineeList);

            // Act
            var result = await _controller.GetTraineeList(batchId);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<object>>());
            Assert.That(okResult.Value, Is.EqualTo(traineeList));
        }
    }
}