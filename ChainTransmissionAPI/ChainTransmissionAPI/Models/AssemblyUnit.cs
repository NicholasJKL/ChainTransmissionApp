using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChainTransmissionAPI.Models;

public class AssemblyUnit
{
	[Key]
	public required int KSE { get; set; }

	public string TSE { get; set; } = null!;

	public string SM { get; set; } = null!;

	public double t { get; set; }

	public string? s { get; set; }

	public string NSE { get; set; } = null!;

	public int? UnitKU { get; set; }

	public virtual Unit? Unit { get; set; }

	[JsonIgnore]
	public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
