using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimarySchoolManagement.BLL;
using PrimarySchoolManagement.BLL.Interfaces;
using PrimarySchoolManagement.Data;

namespace PrimarySchoolManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthorize("Administrator")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// gets all teachers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                var teachers = await _teacherService.GetTeachersAsync();
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// gets teacher by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            try
            {
                var teacher = await _teacherService.GetTeacherAsync(id);

                if (teacher == null)

                    return NotFound();

                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// adds a new teacher
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
        {
            try
            {
                await _teacherService.AddTeacherAsync(teacher);
                return Ok("Teacher added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates teacher by id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            try
            {
                if (id != teacher.Id)
                    return BadRequest("Invalid Teacgher ID.");

                await _teacherService.UpdateTeacherAsync(teacher);

                return Ok("Teacher updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// deletes teacher by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            try
            {
                await _teacherService.DeleteTeacherAsync(id);

                return Ok("Teacher deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// filter teacher by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("filter")]
        public async Task<IActionResult> FilterTeacherByName([FromQuery] string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Name parameter is required for filtering.");
                }

                var filteredTeacher = await _teacherService.FilterTeacherAsyncByName(name);

                if (filteredTeacher == null || filteredTeacher.Count == 0)
                {
                    return NotFound("No teahcer found matching the given criteria.");
                }

                return Ok(filteredTeacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
