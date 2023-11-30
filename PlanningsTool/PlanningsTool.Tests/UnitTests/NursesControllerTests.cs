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
        private NursesController _controller;
        private Mock<INursesService> _nursesServiceMock;

        [TestInitialize]
        public void Setup()
        {
            _nursesServiceMock = new Mock<INursesService>();
            _controller = new NursesController(_nursesServiceMock.Object);
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

        [TestMethod]
        public async Task GetAll_ReturnsOkResultWithNurses()
        {
            // Arrange
            var testNurses = GetTestNurses();
            _nursesServiceMock.Setup(repo => repo.GetAll()).ReturnsAsync(testNurses);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var nurses = (IEnumerable<NurseDTO>)okResult.Value;
            CollectionAssert.AreEqual(testNurses.ToList(), nurses.ToList());
        }

        [TestMethod]
        public async Task GetById_ReturnsOkResultWithNurse()
        {
            // Arrange
            var testNurse = GetTestNurses().FirstOrDefault();
            _nursesServiceMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(testNurse);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var nurse = (NurseDTO)okResult.Value;
            Assert.AreEqual(testNurse, nurse);
        }

        [TestMethod]
        public async Task GetNursesByFirstName_ReturnsOkResultWithNurses()
        {
            // Arrange
            var testNurses = GetTestNurses();
            _nursesServiceMock.Setup(repo => repo.GetNursesByFirstName(It.IsAny<string>())).ReturnsAsync(testNurses);

            // Act
            var result = await _controller.GetNursesByFirstName("John");

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var nurses = (IEnumerable<NurseDTO>)okResult.Value;
            CollectionAssert.AreEqual(testNurses.ToList(), nurses.ToList());
        }

        [TestMethod]
        public async Task GetNursesByLastName_ReturnsOkResultWithNurses()
        {
            // Arrange
            var testNurses = GetTestNurses();
            _nursesServiceMock.Setup(repo => repo.GetNursesByLastName(It.IsAny<string>())).ReturnsAsync(testNurses);

            // Act
            var result = await _controller.GetNursesByLastName("Doe");

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var nurses = (IEnumerable<NurseDTO>)okResult.Value;
            CollectionAssert.AreEqual(testNurses.ToList(), nurses.ToList());
        }

        [TestMethod]
        public async Task Post_ReturnsOkResultWithCreatedNurse()
        {
            // Arrange
            var createNurseDTO = new CreateNurseDTO { FirstName = "John", LastName = "Doe", RegimeTypeId = 1, IsFixedNight = false };
            var createdNurse = new NurseDTO { Id = 1, FirstName = "John", LastName = "Doe", RegimeTypeId = 1, IsFixedNight = false };

            _nursesServiceMock.Setup(repo => repo.Add(It.IsAny<CreateNurseDTO>())).ReturnsAsync(createdNurse);

            // Act
            var result = await _controller.Post(createNurseDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var nurse = (CreateNurseDTO)okResult.Value;

            // Assert the properties of the returned object
            Assert.AreEqual(createNurseDTO.FirstName, nurse.FirstName);
            Assert.AreEqual(createNurseDTO.LastName, nurse.LastName);
            Assert.AreEqual(createNurseDTO.RegimeTypeId, nurse.RegimeTypeId);
            Assert.AreEqual(createNurseDTO.IsFixedNight, nurse.IsFixedNight);
        }




        [TestMethod]
        public async Task Put_ReturnsOkResultWithUpdatedNurse()
        {
            // Arrange
            int nurseId = 1;
            var updateNurseDTO = new UpdateNurseDTO { FirstName = "UpdatedFirstName", LastName = "UpdatedLastName", RegimeTypeId = 2, IsFixedNight = true };
            var existingNurse = new NurseDTO { Id = nurseId, FirstName = "John", LastName = "Doe", RegimeTypeId = 1, IsFixedNight = false };
            var updatedNurse = new NurseDTO { Id = nurseId, FirstName = "UpdatedFirstName", LastName = "UpdatedLastName", RegimeTypeId = 2, IsFixedNight = true };

            _nursesServiceMock.Setup(repo => repo.Update(nurseId, updateNurseDTO)).ReturnsAsync(updatedNurse);
            _nursesServiceMock.Setup(repo => repo.GetById(nurseId)).ReturnsAsync(existingNurse);

            // Act
            var result = await _controller.Put(nurseId, updateNurseDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var nurse = (UpdateNurseDTO)okResult.Value;

            // Assert the properties of the returned object
            Assert.AreEqual(updateNurseDTO.FirstName, nurse.FirstName);
            Assert.AreEqual(updateNurseDTO.LastName, nurse.LastName);
            Assert.AreEqual(updateNurseDTO.RegimeTypeId, nurse.RegimeTypeId);
            Assert.AreEqual(updateNurseDTO.IsFixedNight, nurse.IsFixedNight);
        }


        [TestMethod]
        public async Task Delete_ReturnsNoContentResult()
        {
            // Arrange
            var testNurseId = 1;
            _nursesServiceMock.Setup(repo => repo.GetById(testNurseId)).ReturnsAsync(GetTestNurses().FirstOrDefault());

            // Act
            var result = await _controller.Delete(testNurseId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

    }
}
