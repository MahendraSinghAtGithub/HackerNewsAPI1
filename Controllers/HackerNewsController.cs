
using HackerNewsAPI.Modal.DTO;
using HackerNewsAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security;
using System.Text.Json.Serialization;

namespace HackerNewsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HackerNewsController : ControllerBase
    {
        public readonly IHackerNewsService _hackerNewsService;
        public HackerNewsController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }


        [HttpGet(Name = "GetTopStories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(IEnumerable<StoryDTO>))]
        public async Task<IActionResult> GetTopStories()
        {
            return Ok(await _hackerNewsService.GetNewStories());
        }
    }
}
