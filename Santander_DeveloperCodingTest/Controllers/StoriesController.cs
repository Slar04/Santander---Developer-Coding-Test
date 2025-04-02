using Microsoft.AspNetCore.Mvc;
using SantanderDeveloperCodingTest.Services.Services.Interfaces;

namespace Santander_DeveloperCodingTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly IStoriesService _storiesService;

        public StoriesController(IStoriesService storiesService)
        {
            _storiesService = storiesService;
        }

        [HttpGet("{count}")]
        public async Task<IActionResult> GetBestStories(int count)
        {
            if (count <= 0)
                return BadRequest("Count must be greater than zero.");

            try
            {
                var sortedStories = await _storiesService.GetBestStories(count);

                return Ok(sortedStories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
