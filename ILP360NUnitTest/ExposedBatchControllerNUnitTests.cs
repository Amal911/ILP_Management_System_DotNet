using ILPManagementSystem.Controllers;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Moq;
using NUnit.Framework;

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
    }
}



