using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Domain.Entities;

namespace ProductService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FranchiseController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly ILogger<FranchiseController> _logger;

        public FranchiseController(IFranchiseService franchiseService, ILogger<FranchiseController> logger)
        {
            _franchiseService = franchiseService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new franchise.
        /// </summary>
        /// <param name="franchiseDto">Franchise data transfer object containing the details of the franchise to be created.</param>
        /// <returns>A response indicating the result of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateFranchiseAsync([FromBody] FranchiseDto franchiseDto)
        {

            await _franchiseService.CreateFranchisAsync(franchiseDto);

            // Ensure the route for GetFranchiseByIdAsync is correct
            return Created();
        }

        // GET: api/franchise/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFranchiseByIdAsync(int id)
        {
            var franchise = await _franchiseService.GeFranchisByIdAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }
            return Ok(franchise);
        }

        /// <summary>
        /// Retrieves all franchises.
        /// </summary>
        /// <returns>A list of all franchises.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllFranchisesAsync()
        {
            try
            {
                var franchises = await _franchiseService.GetAllFranchisAsync();

                if (franchises == null || !franchises.Any())
                {
                    return NoContent();
                }

                return Ok(franchises);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all franchises.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error.");
            }
        }

        ///// <summary>
        ///// Searches franchises based on the provided filters.
        ///// </summary>
        ///// <param name="name">Name of the franchise to search for.</param>
        ///// <param name="description">Description of the franchise to search for.</param>
        ///// <returns>A list of matching franchises.</returns>
        //[HttpGet("search")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> SearchFranchisesAsync(string? name)
        //{
        //    try
        //    {
        //        var franchises = await _franchiseRepository.SearchAsync(name);

        //        if (franchises == null || !franchises.Any())
        //        {
        //            return NotFound("No matching franchises found.");
        //        }

        //        return Ok(franchises);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error searching for franchises.");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error.");
        //    }
        //}

        /// <summary>
        /// Deletes a franchise by its ID.
        /// </summary>
        /// <param name="id">The ID of the franchise to delete.</param>
        /// <returns>A response indicating the result of the operation.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFranchiseAsync(int id)
        {
            try
            {

                await _franchiseService.DeleteFranchiseAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting franchise.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error.");
            }
        }
    }
}
