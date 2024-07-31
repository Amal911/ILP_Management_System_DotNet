using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILPManagementSystem.Tests.RepositoryTests
{
    [TestFixture]
    public class AssessmentRepositoryTests
    {
        private ApiContext _context;
        private AssessmentRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApiContext(options);
            _repository = new AssessmentRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetAssessments_ReturnsAllAssessments()
        {
            // Arrange
            var assessments = new List<Assessment>
            {
                new Assessment { Id = 1, AssessmentTitle = "Assessment 1" },
                new Assessment { Id = 2, AssessmentTitle = "Assessment 2" },
                new Assessment { Id = 3, AssessmentTitle = "Assessment 3" }
            };

            _context.Assessments.AddRange(assessments);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAssessments();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetAssessmentById_ReturnsAssessmentById()
        {
            // Arrange
            var assessment = new Assessment { Id = 1, AssessmentTitle = "Assessment 1" };

            _context.Assessments.Add(assessment);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAssessmentById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.AssessmentTitle, Is.EqualTo("Assessment 1"));
        }

        [Test]
        public async Task GetAssessmentById_ReturnsNullIfAssessmentNotFound()
        {
            // Act
            var result = await _repository.GetAssessmentById(1);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task CreateAssessment_CreatesNewAssessment()
        {
            // Arrange
            var assessment = new Assessment { Id = 1, AssessmentTitle = "Assessment 1" };

            // Act
            await _repository.CreateAssessment(assessment);

            // Assert
            Assert.That(_context.Assessments.Count(), Is.EqualTo(1));
            Assert.That(_context.Assessments.First().Id, Is.EqualTo(1));
            Assert.That(_context.Assessments.First().AssessmentTitle, Is.EqualTo("Assessment 1"));
        }

        [Test]
        public async Task SubmitMarks_SubmitsMarksForAssessment()
        {
            // Arrange
            var assessment = new Assessment { Id = 1, AssessmentTitle = "Assessment 1" };
            var completedAssessment = new CompletedAssessment { AssessmentId = 1, TraineeId = 1, Score = 10 };

            _context.Assessments.Add(assessment);
            await _context.SaveChangesAsync();

            // Act
            await _repository.SubmitMarks(completedAssessment);

            // Assert
            Assert.That(_context.CompletedAssessment.Count(), Is.EqualTo(1));
            Assert.That(_context.CompletedAssessment.First().AssessmentId, Is.EqualTo(1));
            Assert.That(_context.CompletedAssessment.First().TraineeId, Is.EqualTo(1));
            Assert.That(_context.CompletedAssessment.First().Score, Is.EqualTo(10));
        }

        [Test]
        public async Task GetAssessmentsByBatchId_ReturnsAssessmentsByBatchId()
        {
            // Arrange
            var assessments = new List<Assessment>
            {
                new Assessment { Id = 1, AssessmentTitle = "Assessment 1", BatchId = 1 },
                new Assessment { Id = 2, AssessmentTitle = "Assessment 2", BatchId = 1 },
                new Assessment { Id = 3, AssessmentTitle = "Assessment 3", BatchId = 2 }
            };

            _context.Assessments.AddRange(assessments);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAssessmentsByBatchId(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
        }
    }
}