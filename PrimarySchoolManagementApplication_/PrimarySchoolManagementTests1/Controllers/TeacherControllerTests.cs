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
    public class TeacherControllerTests
    {
        private readonly Mock<ITeacherService> mockTeacherService;
        private readonly TeacherController teacherController;

        public TeacherControllerTests()
        {
            mockTeacherService = new Mock<ITeacherService>();
            teacherController = new TeacherController(mockTeacherService.Object);
        }

        [TestMethod]
        public async Task GetTeachers_Should_Return_OkResult()
        {
            // Arrange
            mockTeacherService.Setup(service => service.GetTeachersAsync()).ReturnsAsync(new List<Teacher>());

            // Act
            var result = await teacherController.GetTeachers();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task GetTeacher_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validTeacherId = 1;
            mockTeacherService.Setup(service => service.GetTeacherAsync(validTeacherId)).ReturnsAsync(new Teacher());

            // Act
            var result = await teacherController.GetTeacher(validTeacherId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task AddTeacher_Should_Return_OkResult()
        {
            // Arrange
            var validTeacher = new Teacher(); // provide valid Teacher object
            mockTeacherService.Setup(service => service.AddTeacherAsync(validTeacher));

            // Act
            var result = await teacherController.AddTeacher(validTeacher);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task UpdateTeacher_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validTeacherId = 1;
            var validTeacher = new Teacher { Id = validTeacherId }; // provide valid Teacher object
            mockTeacherService.Setup(service => service.UpdateTeacherAsync(validTeacher));

            // Act
            var result = await teacherController.UpdateTeacher(validTeacherId, validTeacher);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task DeleteTeacher_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validTeacherId = 1;
            mockTeacherService.Setup(service => service.DeleteTeacherAsync(validTeacherId));

            // Act
            var result = await teacherController.DeleteTeacher(validTeacherId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task FilterTeacherByName_With_Valid_Name_Should_Return_OkResult()
        {
            // Arrange
            var validTeacherName = "John Doe";
            var filteredTeachers = new List<Teacher> { new Teacher { Id = 1, Name = validTeacherName } };
            mockTeacherService.Setup(service => service.FilterTeacherAsyncByName(validTeacherName)).ReturnsAsync(filteredTeachers);

            // Act
            var result = await teacherController.FilterTeacherByName(validTeacherName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var teachers = okResult.Value as List<Teacher>;
            Assert.IsNotNull(teachers);
            Assert.AreEqual(1, teachers.Count);
            Assert.AreEqual(validTeacherName, teachers[0].Name);
        }
    }
}