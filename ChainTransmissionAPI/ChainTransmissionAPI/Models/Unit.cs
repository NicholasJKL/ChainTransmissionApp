using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChainTransmissionAPI.Models;

public class Unit
{
	[Key]
	public required int KU { get; set; }

	public string NU { get; set; } = null!;

	public string TU { get; set; } = null!;

	public string TN { get; set; } = null!;

	public string VU { get; set; } = null!;

	public double N { get; set; }

	[JsonIgnore]
	public virtual ICollection<AssemblyUnit> AssemblyUnits { get; set; } = new List<AssemblyUnit>();
}
