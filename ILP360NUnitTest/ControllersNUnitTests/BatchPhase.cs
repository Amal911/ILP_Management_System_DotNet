using AutoMapper;
using ILPManagementSystem.Controllers;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILPManagementSystem.Tests.Controllers
{
    [TestFixture]
    public class BatchPhaseControllerTests
    {
        private Mock<IBatchPhaseRepository> _mockBatchPhaseRepository;
        private Mock<IMapper> _mockMapper;
        private BatchPhaseController _controller;

        [SetUp]
        public void Setup()
        {
            _mockBatchPhaseRepository = new Mock<IBatchPhaseRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new BatchPhaseController(_mockBatchPhaseRepository.Object, _mockMapper.Object);
        }


        
        [Test]
        public async Task GetBatchPhasesByBatchIdAsync_ReturnsOkResult_WithBatchPhases()
        {
            // Arrange
            int batchId = 1;
            var batchPhases = new List<BatchPhase>
    {
        new BatchPhase { BatchId = batchId, PhaseId = 1, NumberOfDays = 10, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10) },
        new BatchPhase { BatchId = batchId, PhaseId = 2, NumberOfDays = 15, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(15) }
    };
            _mockBatchPhaseRepository.Setup(repo => repo.GetBatchPhasesByBatchIdAsync(batchId))
                                     .ReturnsAsync(batchPhases);

            // Act
            var result = await _controller.GetBatchPhasesByBatchIdAsync(batchId);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<BatchPhase>>());
            Assert.That(okResult.Value, Is.EqualTo(batchPhases));
        }
        [Test]
        public async Task GetBatchPhasesByBatchIdAsync_ReturnsOkResult_WithEmptyList_WhenNoBatchPhasesExist()
        {
            // Arrange
            int batchId = 1;
            var emptyBatchPhases = new List<BatchPhase>();
            _mockBatchPhaseRepository.Setup(repo => repo.GetBatchPhasesByBatchIdAsync(batchId))
                                     .ReturnsAsync(emptyBatchPhases);

            // Act
            var result = await _controller.GetBatchPhasesByBatchIdAsync(batchId);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<BatchPhase>>());
            Assert.That(okResult.Value, Is.Empty);
        }




    }
}

