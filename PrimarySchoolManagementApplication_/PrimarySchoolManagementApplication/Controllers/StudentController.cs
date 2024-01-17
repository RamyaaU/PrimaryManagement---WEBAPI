using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimarySchoolManagement.BLL;
using PrimarySchoolManagement.BLL.Interfaces;
using PrimarySchoolManagement.DAL.Interfaces;
using PrimarySchoolManagement.Data;

namespace PrimarySchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorize("Administrator")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// gets all students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _studentService.GetStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// gets students by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            try
            {
                var student = await _studentService.GetStudentAsync(id);

                if (student == null)

                    return NotFound();

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// adds new student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            try
            {
                await _studentService.AddStudentAsync(student);
                return Ok("Student added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates student by id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                if (id != student.Id)
                    return BadRequest("Invalid student ID.");

                await _studentService.UpdateStudentAsync(student);

                return Ok("Student updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// deletes student by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _studentService.DeleteStudentAsync(id);

                return Ok("Student deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// filters student by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("filter")]
        public async Task<IActionResult> FilterStudentByName([FromQuery] string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Name parameter is required for filtering.");
                }

                var filteredStudent = await _studentService.FilterStudentAsyncByName(name);

                if (filteredStudent == null || filteredStudent.Count == 0)
                {
                    return NotFound("No student found matching the given criteria.");
                }

                return Ok(filteredStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

