using ChainTransmissionAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using ChainTransmissionAPI.Models.Contexts;
using ChainTransmissionAPI.Managers;


namespace ChainTransmissionAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ChainTransmissionController : ControllerBase
	{
		ChainTransmissionContext _db;
		IChainTransmissionManager _manager;

		public ChainTransmissionController(ChainTransmissionContext context, IChainTransmissionManager manager)
		{
			_db = context;
			_manager = manager;
		}

		[HttpPost("/CreateUnit")]
		public async Task<IActionResult> CreateUnit(Unit unit)
		{
			try
			{
				await _db.Units.AddAsync(unit);
				await _db.SaveChangesAsync();

				return Ok(new { id = unit.KU });
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

				return Ok(new { id = assemblyUnit.KSE });
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

				return Ok(new { id = part.KD });
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

		[HttpGet("/GetStatuses")]
		public async Task<IActionResult> GetStatuses(int unitKey)
		{
			string possibleError = await _manager.CalculateUnitVerificationAsync(unitKey);

			if (possibleError.Length > 0)
			{
				return BadRequest(JsonSerializer.Serialize(possibleError));
			}

			var results = await _db.AssemblyUnits.Where(assemblyUnit => assemblyUnit.UnitKU == unitKey).ToListAsync();

			return Ok(results);
		}
	}
}
