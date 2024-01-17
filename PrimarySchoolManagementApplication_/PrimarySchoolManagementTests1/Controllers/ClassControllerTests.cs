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
    [TestClass()]
    public class ClassControllerTests
    {
        private readonly Mock<IClassService> mockClassService;
        private readonly ClassController classController;

        public ClassControllerTests()
        {
            mockClassService = new Mock<IClassService>();
            classController = new ClassController(mockClassService.Object);
        }

        [TestMethod]
        public async Task GetClasses_Should_Return_OkResult()
        {
            // Arrange
            mockClassService.Setup(service => service.GetClassesAsync()).ReturnsAsync(new List<Class>());

            // Act
            var result = await classController.GetClasses();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task GetClass_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validClassId = 1;
            mockClassService.Setup(service => service.GetClassAsync(validClassId)).ReturnsAsync(new Class());

            // Act
            var result = await classController.GetClass(validClassId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task AddClass_Should_Return_OkResult()
        {
            // Arrange
            var validClass = new Class(); // provide valid Class object
            mockClassService.Setup(service => service.AddClassAsync(validClass));

            // Act
            var result = await classController.AddClass(validClass);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task UpdateClass_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validClassId = 1;
            var validClass = new Class { Id = validClassId }; // provide valid Class object
            mockClassService.Setup(service => service.UpdateClassAsync(validClass));

            // Act
            var result = await classController.UpdateClass(validClassId, validClass);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task FilterClassByName_With_Valid_Name_Should_Return_OkResult()
        {
            // Arrange
            var validClassName = "ClassA";
            var filteredClasses = new List<Class> { new Class { Id = 1, Name = validClassName } };
            mockClassService.Setup(service => service.FilterClassAsyncByName(validClassName)).ReturnsAsync(filteredClasses);

            // Act
            var result = await classController.FilterClassByName(validClassName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var classes = okResult.Value as List<Class>;
            Assert.IsNotNull(classes);
            Assert.AreEqual(1, classes.Count);
            Assert.AreEqual(validClassName, classes[0].Name);
        }
    }
}
