using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChainTransmissionAPI.Models;

public class Part
{
	[Key]
	public required int KD { get; set; }

	public string ND { get; set; } = null!;

	public string TD { get; set; } = null!;

	public string? VD { get; set; }

	public string? NaD { get; set; }

	public int? z { get; set; }

	public int? AssemblyUnitKSE { get; set; }

	[JsonIgnore]
	public virtual AssemblyUnit? AssemblyUnit { get; set; }
}
