using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimarySchoolManagement.BLL;
using PrimarySchoolManagement.BLL.Interfaces;
using PrimarySchoolManagement.DAL.Interfaces;
using PrimarySchoolManagement.Data;

namespace PrimarySchoolManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthorize("Administrator")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        /// <summary>
        /// retrieve all classes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetClasses()
        {
            try
            {
                var schools = await _classService.GetClassesAsync();
                return Ok(schools);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// retrieves class by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClass(int id)
        {
            try
            {
                var clas = await _classService.GetClassAsync(id);

                if (clas == null)

                    return NotFound();

                return Ok(clas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// add a new class
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> AddClass([FromBody] Class @class)
        {
            try
            {
                await _classService.AddClassAsync(@class);
                return Ok("CLass added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates existing class by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="class"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, [FromBody] Class @class)
        {
            try
            {
                if (id != @class.Id)
                    return BadRequest("Invalid class ID.");

                await _classService.UpdateClassAsync(@class);

                return Ok("Class updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// filters classes by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("filter")]
        public async Task<IActionResult> FilterClassByName([FromQuery] string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Name parameter is required for filtering.");
                }

                var filteredClass= await _classService.FilterClassAsyncByName(name);

                if (filteredClass == null || filteredClass.Count == 0)
                {
                    return NotFound("No classes found matching the given criteria.");
                }

                return Ok(filteredClass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
