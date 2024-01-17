using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimarySchoolManagement.BLL.Interfaces;
using PrimarySchoolManagement.Data;

namespace PrimarySchoolManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthorize("Administrator")]
    public class DivisionController : ControllerBase
    {
        private readonly IDivisionService _divisionService;

        public DivisionController(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        /// <summary>
        /// gets all divisions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDivisions()
        {
            try
            {
                var divisions = await _divisionService.GetDivisionAsync();
                return Ok(divisions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// gets division by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDivision(int id)
        {
            try
            {
                var division = await _divisionService.GetDivisionAsync(id);

                if (division == null)

                    return NotFound();

                return Ok(division);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// adds new division
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddDivision([FromBody] Division division)
        {
            try
            {
                await _divisionService.AddDivisionAsync(division);
                return Ok("Division added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates division by id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="division"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDivision(int id, [FromBody] Division division)
        {
            try
            {
                if (id != division.Id)
                    return BadRequest("Invalid division ID.");

                await _divisionService.UpdateDivisionAsync(division);

                return Ok("Division updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// filters by division by name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("filter")]
        public async Task<IActionResult> FilterDivisionByName([FromQuery] string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Name parameter is required for filtering.");
                }

                var filteredDivision = await _divisionService.FilterDivisionAsyncByName(name);

                if (filteredDivision == null || filteredDivision.Count == 0)
                {
                    return NotFound("No division found matching the given criteria.");
                }

                return Ok(filteredDivision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}