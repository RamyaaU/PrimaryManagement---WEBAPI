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
    public class StudentControllerTests
    {
        private readonly Mock<IStudentService> mockStudentService;
        private readonly StudentController studentController;

        public StudentControllerTests()
        {
            mockStudentService = new Mock<IStudentService>();
            studentController = new StudentController(mockStudentService.Object);
        }

        [TestMethod]
        public async Task GetStudents_Should_Return_OkResult()
        {
            // Arrange
            mockStudentService.Setup(service => service.GetStudentsAsync()).ReturnsAsync(new List<Student>());

            // Act
            var result = await studentController.GetStudents();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task GetStudent_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validStudentId = 1;
            mockStudentService.Setup(service => service.GetStudentAsync(validStudentId)).ReturnsAsync(new Student());

            // Act
            var result = await studentController.GetStudent(validStudentId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task AddStudent_Should_Return_OkResult()
        {
            // Arrange
            var validStudent = new Student(); // provide valid Student object
            mockStudentService.Setup(service => service.AddStudentAsync(validStudent));

            // Act
            var result = await studentController.AddStudent(validStudent);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task UpdateStudent_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validStudentId = 1;
            var validStudent = new Student { Id = validStudentId }; // provide valid Student object
            mockStudentService.Setup(service => service.UpdateStudentAsync(validStudent));

            // Act
            var result = await studentController.UpdateStudent(validStudentId, validStudent);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task DeleteStudent_With_Valid_Id_Should_Return_OkResult()
        {
            // Arrange
            var validStudentId = 1;
            mockStudentService.Setup(service => service.DeleteStudentAsync(validStudentId));

            // Act
            var result = await studentController.DeleteStudent(validStudentId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task FilterStudentByName_With_Valid_Name_Should_Return_OkResult()
        {
            // Arrange
            var validStudentName = "John Doe";
            var filteredStudents = new List<Student> { new Student { Id = 1, Name = validStudentName } };
            mockStudentService.Setup(service => service.FilterStudentAsyncByName(validStudentName)).ReturnsAsync(filteredStudents);

            // Act
            var result = await studentController.FilterStudentByName(validStudentName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var students = okResult.Value as List<Student>;
            Assert.IsNotNull(students);
            Assert.AreEqual(1, students.Count);
            Assert.AreEqual(validStudentName, students[0].Name);
        }
    }
}