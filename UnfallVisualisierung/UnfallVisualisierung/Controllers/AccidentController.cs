using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UnfallVisualisierung.Model;
using UnfallVisualisierung.Repositories.Interfaces;

namespace UnfallVisualisierung.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AccidentController : ControllerBase
	{
		private readonly ILogger<AccidentController> _logger;
		private readonly IAccidentRepository _accidentRepository;

		public AccidentController(ILogger<AccidentController> logger, IAccidentRepository accidentRepository)
		{
			_logger = logger;
			_accidentRepository = accidentRepository;
		}

		[HttpGet("MapBox")]
		public async Task<IActionResult> Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] FilterOptions filter)
		{
			_logger.LogDebug("GET Data");
			try
			{
				if (startDate > endDate)
				{
					return BadRequest();
				}
				return Ok(await _accidentRepository.GetGeoData(startDate, endDate, filter));
			}
			catch (Exception e)
			{
				_logger.LogError("Error in get: " + e.Message);
				return new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet("Event/{eventId}")]
		public async Task<IActionResult> GetEventById(string eventId)
		{
			_logger.LogDebug("GET event by id");
			try
			{
				if (String.IsNullOrEmpty(eventId))
				{
					return BadRequest();
				}
				return Ok(await _accidentRepository.GetEventById(eventId));
			}
			catch (Exception e)
			{
				_logger.LogError("Error in get: " + e.Message);
				return new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet("FilterFlags")]
		public IActionResult GetFilterFlags() {
			_logger.LogDebug("GET FilterFlags");
			return Ok(new {
				None = (int)FilterOptions.None, 
				Amenity = (int)FilterOptions.Amenity, 
				Bump = (int)FilterOptions.Bump, 
				Crossing = (int)FilterOptions.Crossing,
				GiveWay = (int)FilterOptions.GiveWay,
				Junction = (int)FilterOptions.Junction,
				NoExit = (int)FilterOptions.NoExit,
				Railway = (int)FilterOptions.Railway,
				Roundabout = (int)FilterOptions.Roundabout,
				Station = (int)FilterOptions.Station,
				Stop = (int)FilterOptions.Stop,
				TrafficCalming = (int)FilterOptions.TrafficCalming,
				TrafficSignal = (int)FilterOptions.TrafficSignal,
				TurningLoop = (int)FilterOptions.TurningLoop});
		}
	}
}
