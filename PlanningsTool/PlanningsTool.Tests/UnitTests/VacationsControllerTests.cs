using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanningsTool.API.Controllers;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Vacations;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.Tests.UnitTests
{
    [TestClass]
    public class VacationsControllerTests
    {
        private VacationsController _controller;
        private Mock<IVacationsService> _vacationsServiceMock;

        [TestInitialize]
        public void Setup()
        {
            _vacationsServiceMock = new Mock<IVacationsService>();
            _controller = new VacationsController(_vacationsServiceMock.Object);
        }

        private IEnumerable<VacationDetailDTO> GetTestVacations()
        {
            return new List<VacationDetailDTO>
            {
                new VacationDetailDTO
                {
                    Id = 1,
                    Startdate = new DateTime(2023, 9, 15),
                    Enddate = new DateTime(2023, 9, 15),
                    Reason = "Verlofdagje op vrijdag.",
                    NurseId = 1,
                    VacationTypeId = 1
                },
                new VacationDetailDTO
                {
                    Id = 2,
                    Startdate = new DateTime(2023, 9, 18),
                    Enddate = new DateTime(2023, 9, 24),
                    Reason = "Heel de week ziek geweest.",
                    NurseId = 2,
                    VacationTypeId = 2
                },
                new VacationDetailDTO
                {
                    Id = 3,
                    Startdate = new DateTime(2023, 9, 18),
                    Enddate = new DateTime(2023, 9, 24),
                    Reason = "Test.",
                    NurseId = 3,
                    VacationTypeId = 5
                },
            };
        }

        /// <summary>
        /// GetAll_ReturnsOkResultWithVacations
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task UT_02_01()
        {
            // Arrange
            var testVacations = GetTestVacations();
            _vacationsServiceMock.Setup(repo => repo.GetAllDetails()).ReturnsAsync(testVacations);

            // Act
            var result = await _controller.GetAllDetails();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var vacations = (IEnumerable<VacationDetailDTO>)okResult.Value;
            CollectionAssert.AreEqual(testVacations.ToList(), vacations.ToList());
        }

        /// <summary>
        /// GetById_ReturnsOkResultWithVacation
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task UT_02_02()
        {
            // Arrange
            var testVacation = GetTestVacations().FirstOrDefault();
            _vacationsServiceMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(testVacation);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var vacation = (VacationDetailDTO)okResult.Value;
            Assert.AreEqual(testVacation, vacation);
        }

        /// <summary>
        /// GetVacationsByReason_ReturnsOkResultWithVacations
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task UT_02_03()
        {
            // Arrange
            var testVacations = GetTestVacations();
            _vacationsServiceMock.Setup(repo => repo.GetVacationsByReason(It.IsAny<string>())).ReturnsAsync(testVacations);

            // Act
            var result = await _controller.GetVacationsByReason("Verlofdagje op vrijdag.");

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var vacations = (IEnumerable<VacationDetailDTO>)okResult.Value;
            CollectionAssert.AreEqual(testVacations.ToList(), vacations.ToList());
        }

        /// <summary>
        /// Post_ReturnsOkResultWithCreatedVacation
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task UT_02_04()
        {
            // Arrange
            var createVacationDTO = new CreateVacationDTO 
            {
                Startdate = new DateTime(2023, 9, 15),
                Enddate = new DateTime(2023, 9, 15),
                Reason = "Verlofdagje op vrijdag.",
                NurseId = 1,
                VacationTypeId = 1
            };
            var createdVacation = new VacationDetailDTO 
            {
                Id = 1,
                Startdate = new DateTime(2023, 9, 15),
                Enddate = new DateTime(2023, 9, 15),
                Reason = "Verlofdagje op vrijdag.",
                NurseId = 1,
                VacationTypeId = 1
            };

            _vacationsServiceMock.Setup(repo => repo.Add(It.IsAny<CreateVacationDTO>())).ReturnsAsync(createdVacation);

            // Act
            var result = await _controller.Post(createVacationDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var vacation = (CreateVacationDTO)okResult.Value;

            // Assert the properties of the returned object
            Assert.AreEqual(createVacationDTO.Startdate, vacation.Startdate);
            Assert.AreEqual(createVacationDTO.Enddate, vacation.Enddate);
            Assert.AreEqual(createVacationDTO.Reason, vacation.Reason);
            Assert.AreEqual(createVacationDTO.NurseId, vacation.NurseId);
            Assert.AreEqual(createVacationDTO.VacationTypeId, vacation.VacationTypeId);
        }

        /// <summary>
        /// Put_ReturnsOkResultWithUpdatedVacation
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task UT_02_05()
        {
            // Arrange
            int vacationId = 1;
            var updateVacationDTO = new UpdateVacationDTO 
            {
                Startdate = new DateTime(2023, 9, 18),
                Enddate = new DateTime(2023, 9, 18),
                Reason = "Verlofdagje op maandag.",
                NurseId = 1,
                VacationTypeId = 1
            };
            var existingVacation = new VacationDetailDTO 
            { 
                Id = vacationId,
                Startdate = new DateTime(2023, 9, 15),
                Enddate = new DateTime(2023, 9, 15),
                Reason = "Verlofdagje op vrijdag.",
                NurseId = 1,
                VacationTypeId = 1
            };
            var updatedVacation = new VacationDetailDTO 
            { 
                Id = vacationId,
                Startdate = new DateTime(2023, 9, 18),
                Enddate = new DateTime(2023, 9, 18),
                Reason = "Verlofdagje op maandag.",
                NurseId = 1,
                VacationTypeId = 1
            };

            _vacationsServiceMock.Setup(repo => repo.Update(vacationId, updateVacationDTO)).ReturnsAsync(updatedVacation);
            _vacationsServiceMock.Setup(repo => repo.GetById(vacationId)).ReturnsAsync(existingVacation);

            // Act
            var result = await _controller.Put(vacationId, updateVacationDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            var vacation = (UpdateVacationDTO)okResult.Value;

            // Assert the properties of the returned object
            Assert.AreEqual(updateVacationDTO.Startdate, vacation.Startdate);
            Assert.AreEqual(updateVacationDTO.Enddate, vacation.Enddate);
            Assert.AreEqual(updateVacationDTO.Reason, vacation.Reason);
            Assert.AreEqual(updateVacationDTO.NurseId, vacation.NurseId);
            Assert.AreEqual(updateVacationDTO.VacationTypeId, vacation.VacationTypeId);
        }

        /// <summary>
        /// Delete_ReturnsNoContentResult
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task UT_02_06()
        {
            // Arrange
            var testVacationId = 1;
            _vacationsServiceMock.Setup(repo => repo.GetById(testVacationId)).ReturnsAsync(GetTestVacations().FirstOrDefault());

            // Act
            var result = await _controller.Delete(testVacationId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}
