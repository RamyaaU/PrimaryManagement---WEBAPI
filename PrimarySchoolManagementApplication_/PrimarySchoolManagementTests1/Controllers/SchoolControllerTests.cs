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
    public class SchoolControllerTests
    {
        private readonly Mock<ISchoolService> mockSchoolService;
        private readonly SchoolController schoolController;

        public SchoolControllerTests()
        {
            mockSchoolService = new Mock<ISchoolService>();
            schoolController = new SchoolController(mockSchoolService.Object);
        }

        [TestMethod]
        public async Task GetSchools_Should_Return_OkResult()
        {
            // Arrange
            mockSchoolService.Setup(service => service.GetSchoolsAsync()).ReturnsAsync(new List<School>());

            // Act
            var result = await schoolController.GetSchools();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task GetSchool_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validSchoolId = 1;
            mockSchoolService.Setup(service => service.GetSchoolAsync(validSchoolId)).ReturnsAsync(new School());

            // Act
            var result = await schoolController.GetSchool(validSchoolId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task AddSchool_Should_Return_OkResult()
        {
            // Arrange
            var validSchool = new School(); // provide valid School object
            mockSchoolService.Setup(service => service.AddSchoolAsync(validSchool));

            // Act
            var result = await schoolController.AddSchool(validSchool);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task UpdateSchool_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validSchoolId = 1;
            var validSchool = new School { Id = validSchoolId }; // provide valid School object
            mockSchoolService.Setup(service => service.UpdateSchoolAsync(validSchool));

            // Act
            var result = await schoolController.UpdateSchool(validSchoolId, validSchool);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task DeleteSchool_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validSchoolId = 1;
            mockSchoolService.Setup(service => service.DeleteSchoolAsync(validSchoolId));

            // Act
            var result = await schoolController.DeleteSchool(validSchoolId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task FilterSchoolByName_With_Valid_Name_Should_Return_OkResult()
        {
            // Arrange
            var validSchoolName = "Example School";
            var filteredSchools = new List<School> { new School { Id = 1, Name = validSchoolName } };
            mockSchoolService.Setup(service => service.FilterSchoolAsyncByName(validSchoolName)).ReturnsAsync(filteredSchools);

            // Act
            var result = await schoolController.FilterSchoolByName(validSchoolName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var schools = okResult.Value as List<School>;
            Assert.IsNotNull(schools);
            Assert.AreEqual(1, schools.Count);
            Assert.AreEqual(validSchoolName, schools[0].Name);
        }
    }
}