using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using AutoMapper;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http;

namespace ILPManagementSystem.Tests.ServiceTests
{
    [TestFixture]
    public class AssessmentServiceTests
    {
        private Mock<IAssessmentRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private AssessmentService _service;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IAssessmentRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new AssessmentService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task CreateAssessment_CreatesNewAssessment()
        {
            // Arrange
            var newAssessment = new CreateAssessmentDTO { AssessmentTitle = "Assessment 1" };
            var assessment = new Assessment { Id = 1, AssessmentTitle = "Assessment 1" };
            _mapperMock.Setup(m => m.Map<Assessment>(newAssessment)).Returns(assessment);
            _repositoryMock.Setup(r => r.CreateAssessment(assessment));

            // Act
            await _service.CreateAssessment(newAssessment);

            // Assert
            _repositoryMock.Verify(r => r.CreateAssessment(assessment), Times.Once);
        }

        [Test]
        public async Task CreateAssessment_SetsDueDateTimeAndHandlesDocumentUpload_WhenIsSubmitable()
        {
            // Arrange
            var documentBytes = new byte[] { 1, 2, 3 };
            var formFile = new Mock<IFormFile>();
            formFile.Setup(f => f.OpenReadStream()).Returns(new MemoryStream(documentBytes));
            formFile.Setup(f => f.FileName).Returns("assessment_document.pdf");
            formFile.Setup(f => f.ContentType).Returns("application/pdf");
            formFile.Setup(f => f.Length).Returns(documentBytes.Length);

            var newAssessment = new CreateAssessmentDTO { AssessmentTitle = "Assessment 1", IsSubmitable = true, DueDateTime = DateTime.Now, Document = formFile.Object };
            var assessment = new Assessment { Id = 1, AssessmentTitle = "Assessment 1" };
            _mapperMock.Setup(m => m.Map<Assessment>(newAssessment)).Returns(assessment);

            // Act
            await _service.CreateAssessment(newAssessment);

            // Assert
            Assert.That(assessment.DueDateTime, Is.EqualTo(newAssessment.DueDateTime));
            Assert.That(assessment.DocumentPath, Is.Not.Null);
            Assert.That(assessment.DocumentName, Is.Not.Null);
            Assert.That(assessment.DocumentContentType, Is.Not.Null);
        }

        [Test]
        public async Task GetAssessmentsByBatchId_ReturnsAssessmentsByBatchId()
        {
            // Arrange
            var batchId = 1;
            var assessments = new List<Assessment> { new Assessment { Id = 1, AssessmentTitle = "Assessment 1" } };
            _repositoryMock.Setup(r => r.GetAssessmentsByBatchId(batchId)).ReturnsAsync(assessments);

            // Act
            var result = await _service.GetAssessmentsByBatchId(batchId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Id, Is.EqualTo(assessments.First().Id));
            Assert.That(result.First().AssessmentTitle, Is.EqualTo(assessments.First().AssessmentTitle));
        }

    }
}