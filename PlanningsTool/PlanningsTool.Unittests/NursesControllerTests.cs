using Xunit;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PlanningsTool.Common.DTO.Nurses;
using PlanningsTool.API.Controllers;
using PlanningsTool.BLL.Interfaces;
using AutoMapper;
using PlanningsTool.BLL.Services;
using PlanningsTool.BLL.Validations;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;
using FluentValidation.Results;

namespace PlanningsTool.Unittests
{
    public class NursesControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResultWithNurses()
        {
            // Arrange
            var nursesServiceMock = new Mock<INursesService>();
            nursesServiceMock.Setup(repo => repo.GetAll()).ReturnsAsync(GetTestNurses());
            var controller = new NursesController(nursesServiceMock.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var nurses = Assert.IsAssignableFrom<IEnumerable<NurseDTO>>(okResult.Value);
            Assert.Equal(3, nurses.Count());
        }

        [Fact]
        public async Task GetById_ReturnsOkResultWithNurse()
        {
            // Arrange
            var nursesServiceMock = new Mock<INursesService>();
            var expectedNurse = new NurseDTO { Id = 1, FirstName = "John", LastName = "Doe", RegimeTypeId = 1, IsFixedNight = false };
            nursesServiceMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(expectedNurse);
            var controller = new NursesController(nursesServiceMock.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var nurse = Assert.IsType<NurseDTO>(okResult.Value);
            Assert.Equal(expectedNurse.Id, nurse.Id);
            Assert.Equal(expectedNurse.FirstName, nurse.FirstName);
            Assert.Equal(expectedNurse.LastName, nurse.LastName);
            Assert.Equal(expectedNurse.RegimeTypeId, nurse.RegimeTypeId);
            Assert.Equal(expectedNurse.IsFixedNight, nurse.IsFixedNight);
        }

        [Fact]
        public async Task GetNursesByFirstName_ReturnsOkResultWithNurses()
        {
            // Arrange
            var nursesServiceMock = new Mock<INursesService>();
            var expectedNurses = GetTestNurses();
            nursesServiceMock.Setup(repo => repo.GetNursesByFirstName(It.IsAny<string>())).ReturnsAsync(expectedNurses);
            var controller = new NursesController(nursesServiceMock.Object);

            // Act
            var result = await controller.GetNursesByFirstName("John");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var nurses = Assert.IsAssignableFrom<IEnumerable<NurseDTO>>(okResult.Value);
            Assert.Equal(expectedNurses, nurses);
        }

        private IEnumerable<NurseDTO> GetTestNurses()
        {
            return new List<NurseDTO>
            {
                new NurseDTO { Id = 1, FirstName = "John", LastName = "Doe", RegimeTypeId = 1, IsFixedNight = false },
                new NurseDTO { Id = 2, FirstName = "Jane", LastName = "Smith", RegimeTypeId = 1, IsFixedNight = false  },
                new NurseDTO { Id = 3, FirstName = "Bob", LastName = "Johnson", RegimeTypeId = 1, IsFixedNight = false  }
            };
        }
    }
}
