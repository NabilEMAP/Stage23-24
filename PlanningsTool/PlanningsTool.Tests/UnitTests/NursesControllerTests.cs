using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanningsTool.API.Controllers;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Nurses;

namespace PlanningsTool.Tests.UnitTests
{

    [TestClass]
    public class NursesControllerTests
    {
        // Setup
        private IEnumerable<NurseDTO> GetTestNurses()
        {
            return new List<NurseDTO>
            {
                new NurseDTO { Id = 1, FirstName = "John", LastName = "Doe", RegimeTypeId = 1, IsFixedNight = false },
                new NurseDTO { Id = 2, FirstName = "Jane", LastName = "Smith", RegimeTypeId = 1, IsFixedNight = false  },
                new NurseDTO { Id = 3, FirstName = "Bob", LastName = "Johnson", RegimeTypeId = 1, IsFixedNight = false  }
            };
        }

        [TestMethod]
        public async Task GetAll_ReturnsOkResultWithNurses()
        {
            // Arrange
            var nursesServiceMock = new Mock<INursesService>();
            nursesServiceMock.Setup(repo => repo.GetAll()).ReturnsAsync(GetTestNurses());

            var controller = new NursesController(nursesServiceMock.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var okResult = (OkObjectResult)result;
            var nurses = (IEnumerable<NurseDTO>)okResult.Value;
            Assert.IsNotNull(nurses);
            // Add more specific assertions based on your business logic
        }

        [TestMethod]
        public async Task GetById_ReturnsOkResultWithNurse()
        {
            // Arrange
            var nursesServiceMock = new Mock<INursesService>();
            nursesServiceMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(new NurseDTO { Id = 1, FirstName = "John", LastName = "Doe", RegimeTypeId = 1, IsFixedNight = false });

            var controller = new NursesController(nursesServiceMock.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var okResult = (OkObjectResult)result;
            var nurse = (NurseDTO)okResult.Value;
            Assert.IsNotNull(nurse);
            Assert.AreEqual(1, nurse.Id);
            // Add more specific assertions based on your business logic
        }

        [TestMethod]
        public async Task GetNursesByFirstName_ReturnsOkResultWithNurses()
        {
            // Arrange
            var nursesServiceMock = new Mock<INursesService>();
            nursesServiceMock.Setup(repo => repo.GetNursesByFirstName(It.IsAny<string>())).ReturnsAsync(GetTestNurses());

            var controller = new NursesController(nursesServiceMock.Object);

            // Act
            var result = await controller.GetNursesByFirstName("John");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var okResult = (OkObjectResult)result;
            var nurses = (IEnumerable<NurseDTO>)okResult.Value;
            Assert.IsNotNull(nurses);
            // Add more specific assertions based on your business logic
        }

        [TestMethod]
        public async Task Post_ReturnsOkResultWithNurse()
        {
            // Arrange
            var nursesServiceMock = new Mock<INursesService>();
            nursesServiceMock.Setup(repo => repo.Add(It.IsAny<CreateNurseDTO>())).ReturnsAsync(new NurseDTO { Id = 1, FirstName = "John", LastName = "Doe" });

            var controller = new NursesController(nursesServiceMock.Object);

            // Act
            var result = await controller.Post(new CreateNurseDTO { FirstName = "John", LastName = "Doe" });

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var okResult = (OkObjectResult)result;
            var nurse = (CreateNurseDTO)okResult.Value;
            Assert.IsNotNull(nurse);
            // Add more specific assertions based on your business logic
        }


        [TestMethod]
        public async Task Put_ReturnsOkResultWithUpdatedNurse()
        {
            // Arrange
            var nursesServiceMock = new Mock<INursesService>();
            nursesServiceMock.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<UpdateNurseDTO>())).ReturnsAsync(new NurseDTO { Id = 1, FirstName = "UpdatedJohn", LastName = "UpdatedDoe" });

            var controller = new NursesController(nursesServiceMock.Object);

            // Act
            var result = await controller.Put(1, new UpdateNurseDTO { FirstName = "UpdatedJohn", LastName = "UpdatedDoe" });

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var okResult = (OkObjectResult)result;
            var updatedNurse = (UpdateNurseDTO)okResult.Value;
            Assert.IsNotNull(updatedNurse);
            // Add more specific assertions based on your business logic
        }

        [TestMethod]
        public async Task Delete_ReturnsNoContentResult()
        {
            // Arrange
            var nursesServiceMock = new Mock<INursesService>();
            nursesServiceMock.Setup(repo => repo.Delete(It.IsAny<int>())).ReturnsAsync(0);

            var controller = new NursesController(nursesServiceMock.Object);

            // Act
            var result = await controller.Delete(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContentResult)); //Error
        }

    }
}
