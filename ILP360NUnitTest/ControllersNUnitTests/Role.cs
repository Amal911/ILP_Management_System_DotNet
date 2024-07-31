using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ILPManagementSystem.Controllers;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ILP360NUnitTest
{
    [TestFixture]
    public class RoleControllerNUnitTests
    {
        private RoleController _controller;
        private Mock<IRoleRepository> _mockRoleRepository;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockRoleRepository = new Mock<IRoleRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new RoleController(_mockRoleRepository.Object, null);
        }





        [Test]
        public async Task UpdateRole_ReturnsBadRequest_WhenIdsDoNotMatch()
        {
            // Arrange
            int roleId = 1;
            var roleDto = new RoleDTO { Id = 2, RoleName = "Updated Role" };

            // Act
            var result = await _controller.UpdateRole(roleId, roleDto);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }



        [Test]
        public async Task DeleteRole_ReturnsNotFound_WhenRoleDoesNotExist()
        {
            // Arrange
            int roleId = 1;
            _mockRoleRepository.Setup(repo => repo.GetRoleByIdAsync(roleId)).ReturnsAsync((Role)null);

            // Act
            var result = await _controller.DeleteRole(roleId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task UpdateRole_ReturnsNotFound_WhenRoleDoesNotExist()
        {
            // Arrange
            int roleId = 1;
            var roleDto = new RoleDTO { Id = roleId, RoleName = "Updated Role" };
            _mockRoleRepository.Setup(repo => repo.GetRoleByIdAsync(roleId)).ReturnsAsync((Role)null);

            // Act
            var result = await _controller.UpdateRole(roleId, roleDto);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }





    }

}









