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
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        /// <summary>
        /// gets all school
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSchools()
        {
            try
            {
                var schools = await _schoolService.GetSchoolsAsync();
                return Ok(schools);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// get all schools
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchool(int id)
        {
            try
            {
                var school = await _schoolService.GetSchoolAsync(id);

                if (school == null)

                    return NotFound();

                return Ok(school);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// add a new school
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSchool([FromBody] School school)
        {
            try
            {
                await _schoolService.AddSchoolAsync(school);
                return Ok("School added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates existing school by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="school"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(int id, [FromBody] School school)
        {
            try
            {
                if (id != school.Id)
                    return BadRequest("Invalid school ID.");

                await _schoolService.UpdateSchoolAsync(school);

                return Ok("School updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// deletes school by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            try
            {
                await _schoolService.DeleteSchoolAsync(id);

                return Ok("School deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("filter")]
        //public async Task<IActionResult> FilterSchool(string location)
        //{
        //    var filteredSchools = await _schoolService.GetFilteredSchoolsAsync();
        //     return Ok(filteredSchools);
        //}

        /// <summary>
        /// filters school by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("filter")]
        public async Task<IActionResult> FilterSchoolByName([FromQuery] string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Name parameter is required for filtering.");
                }

                var filteredSchool= await _schoolService.FilterSchoolAsyncByName(name);

                if (filteredSchool == null || filteredSchool.Count == 0)
                {
                    return NotFound("No schools found matching the given criteria.");
                }

                return Ok(filteredSchool);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
