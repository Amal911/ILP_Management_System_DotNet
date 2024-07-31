using ILPManagementSystem.Controllers;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
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
    public class LeaveControllerTests
    {
        private Mock<ILeaveRepository> _mockLeaveRepository;
        private Mock<ILeaveApprovalRepository> _mockLeaveApprovalRepository;
        private LeaveController _leaveController;

        [SetUp]
        public void SetUp()
        {
            _mockLeaveRepository = new Mock<ILeaveRepository>();
            _mockLeaveApprovalRepository = new Mock<ILeaveApprovalRepository>();
            _leaveController = new LeaveController(_mockLeaveRepository.Object, _mockLeaveApprovalRepository.Object);
        }

        [Test]
        public async Task UpdateApprovalStatus_ValidApproval_ReturnsNoContent()
        {
            // Arrange
            int leaveId = 1;
            var approvalDto = new LeaveApprovalUpdateDTO { UserId = 2, IsApproved = true };

            var leave = new Leave { Id = leaveId };
            _mockLeaveRepository.Setup(repo => repo.GetLeaveByIdAsync(leaveId)).ReturnsAsync(leave);
            _mockLeaveApprovalRepository.Setup(repo => repo.GetLeaveApprovalAsync(leaveId, 2)).ReturnsAsync(new LeaveApproval { Id = 1, LeavesId = leaveId, userId = 2 });

            // Act
            var result = await _leaveController.UpdateApprovalStatus(leaveId, approvalDto);

            // Assert
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        public async Task UpdateApprovalStatus_LeaveNotFound_ReturnsNotFound()
        {
            // Arrange
            int leaveId = 1;
            var approvalDto = new LeaveApprovalUpdateDTO { UserId = 2, IsApproved = true };

            _mockLeaveRepository.Setup(repo => repo.GetLeaveByIdAsync(leaveId)).ReturnsAsync((Leave)null);

            // Act
            var result = await _leaveController.UpdateApprovalStatus(leaveId, approvalDto);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task GetLeaveRequests_ReturnsOkWithLeaveRequests()
        {
            // Arrange
            var leaves = new List<Leave>
    {
        new Leave
        {
            Id = 1,
            TraineeId = 1,
            NumofDays = 3,
            Reason = "Vacation",
            Description = "Going to beach",
            CreatedDate = DateTime.UtcNow,
            LeaveApprovals = new List<LeaveApproval>()
        }
    };

            var leaveApprovals = new List<LeaveApproval>
    {
        new LeaveApproval { Id = 1, LeavesId = 1, userId = 2, IsApproved = null }
    };

            _mockLeaveRepository.Setup(repo => repo.GetAllLeavesAsync()).ReturnsAsync(leaves);
            _mockLeaveApprovalRepository.Setup(repo => repo.GetAllApprovalsAsync()).ReturnsAsync(leaveApprovals);
            _mockLeaveApprovalRepository.Setup(repo => repo.GetApprovalsByLeaveIdAsync(1)).ReturnsAsync(leaveApprovals);
            _mockLeaveRepository.Setup(repo => repo.GetTraineeWithBatchByIdAsync(1)).ReturnsAsync(new Trainee { UserId = 1 });
            _mockLeaveRepository.Setup(repo => repo.GetUserByIdAsync(1)).ReturnsAsync(new User { FirstName = "John", LastName = "Doe" });

            // Act
            var result = await _leaveController.GetLeaveRequests();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            var leaveRequests = okResult.Value as List<LeaveDTO>;
            Assert.That(leaveRequests.Count, Is.EqualTo(1));
            Assert.That(leaveRequests.First().Name, Is.EqualTo("John Doe"));
        }


        [Test]
        public async Task PostLeaveRequest_TraineeNotFound_ReturnsNotFound()
        {
            // Arrange
            var leaveDto = new LeavecreateDTO { UserID = 1 };
            _mockLeaveRepository.Setup(repo => repo.GetTraineeByUserIDAsync(leaveDto.UserID))
                .ReturnsAsync((Trainee)null);

            // Act
            var result = await _leaveController.PostLeaveRequest(leaveDto);

            // Assert
            Assert.That(result, Is.TypeOf<NotFoundObjectResult>());
        }

        [Test]
        public async Task PostLeaveRequest_OneDayLeaveWithoutDate_ReturnsBadRequest()
        {
            // Arrange
            var trainee = new Trainee { Id = 1, UserId = 1 };
            var leaveDto = new LeavecreateDTO { UserID = 1, NumofDays = 1 };
            _mockLeaveRepository.Setup(repo => repo.GetTraineeByUserIDAsync(leaveDto.UserID))
                .ReturnsAsync(trainee);

            // Act
            var result = await _leaveController.PostLeaveRequest(leaveDto);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task PostLeaveRequest_MultipleDaysLeaveWithoutDateRange_ReturnsBadRequest()
        {
            // Arrange
            var trainee = new Trainee { Id = 1, UserId = 1 };
            var leaveDto = new LeavecreateDTO { UserID = 1, NumofDays = 2 };
            _mockLeaveRepository.Setup(repo => repo.GetTraineeByUserIDAsync(leaveDto.UserID))
                .ReturnsAsync(trainee);

            // Act
            var result = await _leaveController.PostLeaveRequest(leaveDto);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task PostLeaveRequest_ValidRequest_ReturnsOk()
        {
            // Arrange
            var trainee = new Trainee { Id = 1, UserId = 1 };
            var leaveDto = new LeavecreateDTO
            {
                UserID = 1,
                NumofDays = 1,
                LeaveDate = DateTime.UtcNow,
                PocIds = new List<int> { 2, 3 }
            };

            _mockLeaveRepository.Setup(repo => repo.GetTraineeByUserIDAsync(leaveDto.UserID))
                .ReturnsAsync(trainee);

            _mockLeaveRepository.Setup(repo => repo.AddLeaveAsync(It.IsAny<Leave>()))
                .ReturnsAsync(new Leave { Id = 1 });

            // Act
            var result = await _leaveController.PostLeaveRequest(leaveDto);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public async Task PostLeaveRequest_RepositoryThrowsException_ReturnsServerError()
        {
            // Arrange
            var trainee = new Trainee { Id = 1, UserId = 1 };
            var leaveDto = new LeavecreateDTO
            {
                UserID = 1,
                NumofDays = 1,
                LeaveDate = DateTime.UtcNow,
                PocIds = new List<int> { 2, 3 }
            };

            _mockLeaveRepository.Setup(repo => repo.GetTraineeByUserIDAsync(leaveDto.UserID))
                .ReturnsAsync(trainee);

            _mockLeaveRepository.Setup(repo => repo.AddLeaveAsync(It.IsAny<Leave>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _leaveController.PostLeaveRequest(leaveDto);

            // Assert
            Assert.That(result, Is.TypeOf<ObjectResult>());
            var objectResult = result as ObjectResult;
            Assert.That(objectResult.StatusCode, Is.EqualTo(500));
        }


        [Test]
        public async Task UpdateApprovalStatus_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _leaveController.ModelState.AddModelError("UserId", "Required");
            var leaveApprovalUpdateDto = new LeaveApprovalUpdateDTO();

            // Act
            var result = await _leaveController.UpdateApprovalStatus(1, leaveApprovalUpdateDto);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        /* [Test]
         public async Task UpdateApprovalStatus_LeaveNotFound_ReturnsNotFound()
         {
             // Arrange
             var leaveApprovalUpdateDto = new LeaveApprovalUpdateDTO { UserId = 1 };
             _mockLeaveRepository.Setup(repo => repo.GetLeaveByIdAsync(1)).ReturnsAsync((Leave)null);

             // Act
             var result = await _leaveController.UpdateApprovalStatus(1, leaveApprovalUpdateDto);

             // Assert
             Assert.That(result, Is.TypeOf<NotFoundResult>());
         }*/

        [Test]
        public async Task UpdateApprovalStatus_ApprovalNotFound_AddsNewApproval_ReturnsNoContent()
        {
            // Arrange
            var leave = new Leave { Id = 1 };
            var leaveApprovalUpdateDto = new LeaveApprovalUpdateDTO { UserId = 1, IsApproved = true };
            _mockLeaveRepository.Setup(repo => repo.GetLeaveByIdAsync(1)).ReturnsAsync(leave);
            _mockLeaveApprovalRepository.Setup(repo => repo.GetLeaveApprovalAsync(1, leaveApprovalUpdateDto.UserId)).ReturnsAsync((LeaveApproval)null);

            // Act
            var result = await _leaveController.UpdateApprovalStatus(1, leaveApprovalUpdateDto);

            // Assert
            _mockLeaveApprovalRepository.Verify(repo => repo.AddApprovalAsync(It.IsAny<LeaveApproval>()), Times.Once);
            Assert.That(result, Is.TypeOf<NoContentResult>());
        }

        [Test]
        public async Task UpdateApprovalStatus_ExistingApproval_UpdatesApproval_ReturnsNoContent()
        {
            // Arrange
            var leave = new Leave { Id = 1 };
            var leaveApprovalUpdateDto = new LeaveApprovalUpdateDTO { UserId = 1, IsApproved = true };
            var existingApproval = new LeaveApproval { LeavesId = 1, userId = 1, IsApproved = false };
            _mockLeaveRepository.Setup(repo => repo.GetLeaveByIdAsync(1)).ReturnsAsync(leave);
            _mockLeaveApprovalRepository.Setup(repo => repo.GetLeaveApprovalAsync(1, leaveApprovalUpdateDto.UserId)).ReturnsAsync(existingApproval);

            // Act
            var result = await _leaveController.UpdateApprovalStatus(1, leaveApprovalUpdateDto);

            // Assert
            _mockLeaveApprovalRepository.Verify(repo => repo.UpdateApprovalAsync(existingApproval), Times.Once);
            Assert.That(result, Is.TypeOf<NoContentResult>());
        }

    }
}
