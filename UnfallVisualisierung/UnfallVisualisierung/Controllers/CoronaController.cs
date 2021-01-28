using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnfallVisualisierung.Repositories.Interfaces;

namespace UnfallVisualisierung.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoronaController : ControllerBase
    {
        private readonly ILogger<CoronaController> _logger;
        private readonly ICoronaRepository _coronaRepository;

        public CoronaController(ILogger<CoronaController> logger, ICoronaRepository coronaRepository)
        {
            _logger = logger;
            _coronaRepository = coronaRepository;
        }

        [HttpGet("{state}")]
        public async Task<IActionResult> GetCoronaForState(string state)
        {
            if (String.IsNullOrEmpty(state)) return BadRequest();
            return Ok(await _coronaRepository.GetCoronaStatisticByState(state));
        }
    }
}