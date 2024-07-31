using AutoMapper;
using ILPManagementSystem.Controllers;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Sprache;
using System.Net;

namespace ILPManagementSystem.Tests
{
    [TestFixture]
    public class SessionControllerTests
    {
        private Mock<ISessionRepository> _mockSessionRepo;
        private Mock<IMapper> _mockMapper;
        private SessionController _controller;

        [SetUp]
        public void Setup()
        {
            _mockSessionRepo = new Mock<ISessionRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new SessionController(_mockSessionRepo.Object, _mockMapper.Object);
        }

        //1
        [Test]
        public async Task GetAllSessions_ShouldReturnAllSessions_CheckWhetherResultIsNotNull()
        {
            // Arrange
            var sessionsDTO = new List<SessionDTO>
            {
            new SessionDTO
            {
            Id = 1,
            SessionName = "Session 1",
            SessionDescription = "Description 1",
            startTime = DateTime.Now.AddHours(-1),
            endTime = DateTime.Now,
            BatchId = 1,
            TrainerId = 1,
            TrainerName = "Trainer Name" // Assuming this is a static name for simplicity
                }
            };

            // Set up mock repository to return the sessionDTOs
            _mockSessionRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sessionsDTO);
            _mockMapper.Setup(m => m.Map<IEnumerable<SessionDTO>>(It.IsAny<IEnumerable<Session>>()))
                .Returns(sessionsDTO);
            var result = await _controller.GetAllSessions() as OkObjectResult;
            // Act
            ClassicAssert.NotNull(result);
        }

        //2
        [Test]
        public async Task GetAllSessions_ShouldReturnAllSessions_CheckWhetherStatusCodeIs200()
        {
            // Arrange
            var sessionsDTO = new List<SessionDTO>
                {
                    new SessionDTO
                        {
                            Id = 1,
                            SessionName = "Session 1",
                            SessionDescription = "Description 1",
                            startTime = DateTime.Now.AddHours(-1),
                            endTime = DateTime.Now,
                            BatchId = 1,
                            TrainerId = 1,
                            TrainerName = "Trainer Name" // Assuming this is a static name for simplicity
                         }
                     };

            // Set up mock repository to return the sessionDTOs
            _mockSessionRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sessionsDTO);
            _mockMapper.Setup(m => m.Map<IEnumerable<SessionDTO>>(It.IsAny<IEnumerable<Session>>()))
                .Returns(sessionsDTO);
            var result = await _controller.GetAllSessions() as OkObjectResult;
            // Act
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }

        //3
        [Test]
        public async Task GetAllSessions_ShouldReturnAllSessions_ChangeItToResponseFormat_CheckWhetherItIsNull()
        {
            // Arrange
            var sessionsDTO = new List<SessionDTO>
                {
                    new SessionDTO
                        {
                            Id = 1,
                            SessionName = "Session 1",
                            SessionDescription = "Description 1",
                            startTime = DateTime.Now.AddHours(-1),
                            endTime = DateTime.Now,
                            BatchId = 1,
                            TrainerId = 1,
                            TrainerName = "Trainer Name" // Assuming this is a static name for simplicity
                         }
                     };

            // Set up mock repository to return the sessionDTOs
            _mockSessionRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sessionsDTO);
            _mockMapper.Setup(m => m.Map<IEnumerable<SessionDTO>>(It.IsAny<IEnumerable<Session>>()))
                .Returns(sessionsDTO);
            var result = await _controller.GetAllSessions() as OkObjectResult;
            // Act

            var apiResponse = result.Value as APIResponse;
            ClassicAssert.NotNull(apiResponse);
        }

        //4
        [Test]
        public async Task GetAllSessions_ShouldReturnAllSessions_ChangeItToResponseFormat_CheckWhetherIsSuccessIsTrue()
        {
            // Arrange
            var sessionsDTO = new List<SessionDTO>
                {
                    new SessionDTO
                        {
                            Id = 1,
                            SessionName = "Session 1",
                            SessionDescription = "Description 1",
                            startTime = DateTime.Now.AddHours(-1),
                            endTime = DateTime.Now,
                            BatchId = 1,
                            TrainerId = 1,
                            TrainerName = "Trainer Name" // Assuming this is a static name for simplicity
                         }
                     };

            // Set up mock repository to return the sessionDTOs
            _mockSessionRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sessionsDTO);
            _mockMapper.Setup(m => m.Map<IEnumerable<SessionDTO>>(It.IsAny<IEnumerable<Session>>()))
                .Returns(sessionsDTO);
            var result = await _controller.GetAllSessions() as OkObjectResult;
            // Act

            var apiResponse = result.Value as APIResponse;
            ClassicAssert.IsTrue(apiResponse.IsSuccess);
        }

        //5
        [Test]
        public async Task GetAllSessions_ShouldReturnAllSessions_ChangeItToResponseFormat_CheckWhetherTheStatusCodeIsOk()
        {
            // Arrange
            var sessionsDTO = new List<SessionDTO>
                {
                    new SessionDTO
                        {
                            Id = 1,
                            SessionName = "Session 1",
                            SessionDescription = "Description 1",
                            startTime = DateTime.Now.AddHours(-1),
                            endTime = DateTime.Now,
                            BatchId = 1,
                            TrainerId = 1,
                            TrainerName = "Trainer Name" // Assuming this is a static name for simplicity
                         }
                     };

            // Set up mock repository to return the sessionDTOs
            _mockSessionRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sessionsDTO);
            _mockMapper.Setup(m => m.Map<IEnumerable<SessionDTO>>(It.IsAny<IEnumerable<Session>>()))
                .Returns(sessionsDTO);
            var result = await _controller.GetAllSessions() as OkObjectResult;
            // Act

            var apiResponse = result.Value as APIResponse;
            ClassicAssert.AreEqual(HttpStatusCode.OK, apiResponse.StatusCode);
        }

        //6
        [Test]
        public async Task GetAllSessions_ShouldReturnAllSessions_ChangeItToResponseFormat_CheckWhetherTheNumberOfReturnedSessionsAreAsExpected()
        {
            // Arrange
            var sessionsDTO = new List<SessionDTO>
                {
                    new SessionDTO
                        {
                            Id = 1,
                            SessionName = "Session 1",
                            SessionDescription = "Description 1",
                            startTime = DateTime.Now.AddHours(-1),
                            endTime = DateTime.Now,
                            BatchId = 1,
                            TrainerId = 1,
                            TrainerName = "Trainer Name" // Assuming this is a static name for simplicity
                         }
                     };

            // Set up mock repository to return the sessionDTOs
            _mockSessionRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sessionsDTO);
            _mockMapper.Setup(m => m.Map<IEnumerable<SessionDTO>>(It.IsAny<IEnumerable<Session>>()))
                .Returns(sessionsDTO);
            var result = await _controller.GetAllSessions() as OkObjectResult;
            // Act
            var apiResponse = result.Value as APIResponse;
            var resultDTOs = apiResponse.Result as ICollection<SessionDTO>;
            ClassicAssert.AreEqual(sessionsDTO.Count, resultDTOs.Count);
        }

        //7
        [Test]
        public async Task GetAllSessions_ShouldReturnAllSessions_ChangeItToResponseFormat_CheckWhetherTheValueOfSessionsAreAsExpected()
        {
            // Arrange
            var sessionsDTO = new List<SessionDTO>
                {
                    new SessionDTO
                        {
                            Id = 1,
                            SessionName = "Session 1",
                            SessionDescription = "Description 1",
                            startTime = DateTime.Now.AddHours(-1),
                            endTime = DateTime.Now,
                            BatchId = 1,
                            TrainerId = 1,
                            TrainerName = "Trainer Name" // Assuming this is a static name for simplicity
                         }
                     };

            // Set up mock repository to return the sessionDTOs
            _mockSessionRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sessionsDTO);
            _mockMapper.Setup(m => m.Map<IEnumerable<SessionDTO>>(It.IsAny<IEnumerable<Session>>()))
                .Returns(sessionsDTO);
            var result = await _controller.GetAllSessions() as OkObjectResult;
            // Act
            var apiResponse = result.Value as APIResponse;
            var resultDTOs = apiResponse.Result as ICollection<SessionDTO>;
            foreach (var expectedDto in sessionsDTO)
            {
                var actualDto = resultDTOs.FirstOrDefault(dto => dto.Id == expectedDto.Id);
                ClassicAssert.NotNull(actualDto);
                ClassicAssert.AreEqual(expectedDto.SessionName, actualDto.SessionName);
                ClassicAssert.AreEqual(expectedDto.SessionDescription, actualDto.SessionDescription);
                ClassicAssert.AreEqual(expectedDto.startTime, actualDto.startTime);
                ClassicAssert.AreEqual(expectedDto.endTime, actualDto.endTime);
                ClassicAssert.AreEqual(expectedDto.BatchId, actualDto.BatchId);
                ClassicAssert.AreEqual(expectedDto.TrainerId, actualDto.TrainerId);
                ClassicAssert.AreEqual(expectedDto.TrainerName, actualDto.TrainerName);
            }
        }
       
    }
}
