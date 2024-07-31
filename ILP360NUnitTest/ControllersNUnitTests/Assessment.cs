using NUnit.Framework;
using Moq;
using AutoMapper;
using ILPManagementSystem.Services;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ILPManagementSystem.Controllers;

namespace ILP360NUnitTest.ControllersNUnitTests
{
    [TestFixture]
    public class AssessmentControllerTests
    {
        private Mock<AssessmentService> _mockService;
        private Mock<AssessmentRepository> _mockRepository;
        private Mock<ApiContext> _mockContext;
        private AssessmentController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<AssessmentService>(null, null);
            _mockRepository = new Mock<AssessmentRepository>(null);
            _mockContext = new Mock<ApiContext>(new DbContextOptions<ApiContext>());
            _controller = new AssessmentController(_mockService.Object, _mockRepository.Object, _mockContext.Object);
        }


        [Test]
        public async Task CreateAssessment_WithInvalidModel_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Error", "Invalid model");

            // Act
            var result = await _controller.CreateAssessment(new CreateAssessmentDTO());

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

    }
}
