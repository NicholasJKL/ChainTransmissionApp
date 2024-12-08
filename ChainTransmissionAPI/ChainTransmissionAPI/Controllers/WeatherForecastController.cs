using ChainTransmissionAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;


namespace ChainTransmissionAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		ChainTransmissionContext _db;

		public WeatherForecastController(ChainTransmissionContext context)
		{
			_db = context;
		}

		[HttpPost("/CreateUnit")]
		public async Task<IActionResult> CreateUnit(Unit unit)
		{
			try
			{
				await _db.Units.AddAsync(unit);
				await _db.SaveChangesAsync();

				return Created();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("/CreateAssemblyUnit")]
		public async Task<IActionResult> CreateAssemblyUnit(AssemblyUnit assemblyUnit)
		{
			try
			{
				var unit = await _db.Units.FindAsync(assemblyUnit.UnitKU);

				assemblyUnit.Unit = unit;

				await _db.AssemblyUnits.AddAsync(assemblyUnit);
				await _db.SaveChangesAsync();

				return Created();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("/CreatePart")]
		public async Task<IActionResult> CreatePart(Part part)
		{
			try
			{
				var assemblyUnit = await _db.AssemblyUnits.FindAsync(part.AssemblyUnitKSE);

				part.AssemblyUnit = assemblyUnit;

				await _db.Parts.AddAsync(part);
				await _db.SaveChangesAsync();

				return Created();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("/GetUnits")]
		public async Task<IActionResult> GetUnits()
		{
			var units = await _db.Units.ToListAsync();

			return Ok(units);
		}

		[HttpGet("/GetAssemblyUnitsByUnit")]
		public async Task<IActionResult> GetAssemblyUnitsByUnit(int unitKey)
		{
			var assemblyUnits = await _db.AssemblyUnits.Where(assemblyUnit => assemblyUnit.UnitKU == unitKey).ToListAsync();

			return Ok(assemblyUnits);
		}

		[HttpGet("/GetPartsByAssemblyUnit")]
		public async Task<IActionResult> GetPartsByAssemblyUnit(int assemblyUnitKey)
		{
			var parts = await _db.Parts.Where(part => part.AssemblyUnitKSE == assemblyUnitKey).ToListAsync();

			return Ok(parts);
		}
	}
}
