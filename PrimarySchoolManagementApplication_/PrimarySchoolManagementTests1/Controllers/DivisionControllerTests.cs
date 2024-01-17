using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrimarySchoolManagement.BLL.Interfaces;
using PrimarySchoolManagement.Controllers;
using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.Controllers.PrimarySchoolManagementTests
{
    [TestClass]
    public class DivisionControllerTests
    {
        private readonly Mock<IDivisionService> mockDivisionService;
        private readonly DivisionController divisionController;

        public DivisionControllerTests()
        {
            mockDivisionService = new Mock<IDivisionService>();
            divisionController = new DivisionController(mockDivisionService.Object);
        }

        [TestMethod]
        public async Task GetDivisions_Should_Return_OkResult()
        {
            // Arrange
            mockDivisionService.Setup(service => service.GetDivisionAsync()).ReturnsAsync(new List<Division>());

            // Act
            var result = await divisionController.GetDivisions();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task GetDivision_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validDivisionId = 1;
            mockDivisionService.Setup(service => service.GetDivisionAsync(validDivisionId)).ReturnsAsync(new Division());

            // Act
            var result = await divisionController.GetDivision(validDivisionId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task AddDivision_Should_Return_OkResult()
        {
            // Arrange
            var validDivision = new Division(); 
            mockDivisionService.Setup(service => service.AddDivisionAsync(validDivision));

            // Act
            var result = await divisionController.AddDivision(validDivision);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task UpdateDivision_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validDivisionId = 1;
            var validDivision = new Division { Id = validDivisionId }; 
            mockDivisionService.Setup(service => service.UpdateDivisionAsync(validDivision));

            // Act
            var result = await divisionController.UpdateDivision(validDivisionId, validDivision);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task FilterDivisionByName_With_Valid_Name_Should_Return_OkResult()
        {
            // Arrange
            var validDivisionName = "Math";
            var filteredDivisions = new List<Division> { new Division { Id = 1, Name = validDivisionName } };
            mockDivisionService.Setup(service => service.FilterDivisionAsyncByName(validDivisionName)).ReturnsAsync(filteredDivisions);

            // Act
            var result = await divisionController.FilterDivisionByName(validDivisionName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var divisions = okResult.Value as List<Division>;
            Assert.IsNotNull(divisions);
            Assert.AreEqual(1, divisions.Count);
            Assert.AreEqual(validDivisionName, divisions[0].Name);
        }
    }
}