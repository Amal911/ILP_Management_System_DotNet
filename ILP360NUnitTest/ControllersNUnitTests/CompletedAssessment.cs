using AutoMapper;
using ILPManagementSystem.Controllers;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILP360NUnitTest
{
    [TestFixture]
    public class CompletedAssessmentControllerNUnitTests
    {
        private CompletedAssessmentsController _controller;
        private Mock<ICompletedAssessmentRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<ICompletedAssessmentRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new CompletedAssessmentsController(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetById_ReturnsOkResult_WithCompletedAssessmentDTO_WhenAssessmentExists()
        {
            // Arrange
            var assessment = new CompletedAssessment
            {
                Id = 1,
                TraineeId = 1,
                Score = 85.5
            };
            var assessmentDTO = new CompletedAssessmentDTO
            {
                AssessmentIdString = "1",
                TraineeId = 1,
                Score = 85.5
            };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(assessment);
            _mockMapper.Setup(m => m.Map<CompletedAssessmentDTO>(assessment)).Returns(assessmentDTO);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<CompletedAssessmentDTO>());
            Assert.That(okResult.Value, Is.EqualTo(assessmentDTO));
        }

        [Test]
        public async Task GetById_ReturnsNotFound_WhenAssessmentDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CompletedAssessment)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task GetAll_ReturnsOkResult_WithListOfCompletedAssessmentDTOs()
        {
            // Arrange
            var assessments = new List<CompletedAssessment>
            {
                new CompletedAssessment { Id = 1, TraineeId = 1, Score = 85.5 },
                new CompletedAssessment { Id = 2, TraineeId = 2, Score = 90.0 }
            };
            var assessmentDTOs = new List<CompletedAssessmentDTO>
            {
                new CompletedAssessmentDTO { AssessmentIdString = "1", TraineeId = 1, Score = 85.5 },
                new CompletedAssessmentDTO { AssessmentIdString = "2", TraineeId = 2, Score = 90.0 }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(assessments);
            _mockMapper.Setup(m => m.Map<IEnumerable<CompletedAssessmentDTO>>(assessments)).Returns(assessmentDTOs);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<CompletedAssessmentDTO>>());
            Assert.That(okResult.Value, Is.EquivalentTo(assessmentDTOs));
        }

        [Test]
        public async Task Create_ReturnsCreatedAtActionResult_WithCompletedAssessmentDTO()
        {
            // Arrange
            var assessmentDTO = new CompletedAssessmentDTO
            {
                AssessmentIdString = "1",
                TraineeId = 1,
                Score = 85.5
            };
            var assessment = new CompletedAssessment
            {
                Id = 1,
                TraineeId = 1,
                Score = 85.5
            };
            _mockMapper.Setup(m => m.Map<CompletedAssessment>(assessmentDTO)).Returns(assessment);
            _mockRepository.Setup(repo => repo.AddAsync(assessment)).ReturnsAsync(assessment);
            _mockMapper.Setup(m => m.Map<CompletedAssessmentDTO>(assessment)).Returns(assessmentDTO);

            // Act
            var result = await _controller.Create(assessmentDTO);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.That(createdResult.ActionName, Is.EqualTo("GetById"));
            Assert.That(createdResult.RouteValues["id"], Is.EqualTo(assessment.Id));
            Assert.That(createdResult.Value, Is.InstanceOf<CompletedAssessmentDTO>());
            Assert.That(createdResult.Value, Is.EqualTo(assessmentDTO));
        }
        [Test]
        public async Task GetAll_ReturnsOkResult_WithEmptyList_WhenNoAssessmentsExist()
        {
            // Arrange
            var assessments = new List<CompletedAssessment>();
            var assessmentDTOs = new List<CompletedAssessmentDTO>();
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(assessments);
            _mockMapper.Setup(m => m.Map<IEnumerable<CompletedAssessmentDTO>>(assessments)).Returns(assessmentDTOs);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<CompletedAssessmentDTO>>());
            Assert.That(okResult.Value, Is.Empty);
        }
        [Test]
        public async Task GetById_ReturnsNotFound_WhenInvalidAssessmentIdIsProvided()
        {
            // Arrange
            int invalidId = 999; // Assuming this ID does not exist in the repository
            _mockRepository.Setup(repo => repo.GetByIdAsync(invalidId)).ReturnsAsync((CompletedAssessment)null);

            // Act
            var result = await _controller.GetById(invalidId);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
        }








    }
}
