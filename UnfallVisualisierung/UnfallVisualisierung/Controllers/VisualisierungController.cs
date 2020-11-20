using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UnfallVisualisierung.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisualisierungController : ControllerBase
    {
        private readonly ILogger<VisualisierungController> _logger;

        public VisualisierungController(ILogger<VisualisierungController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogDebug("GET");
            return "hi";
        }
    }
}
