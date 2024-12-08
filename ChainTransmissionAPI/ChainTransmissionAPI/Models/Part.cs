using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChainTransmissionAPI.Models;

public class Part
{
	[Key]
	public int KD { get; set; }

	public string ND { get; set; } = null!;

	public string TD { get; set; } = null!;

	public string? VD { get; set; }

	public string? NaD { get; set; }

	public double? S { get; set; }

	public double? K_m { get; set; }

	public double? K_z { get; set; }

	public double? K_t { get; set; }

	public double? tc { get; set; }

	public double? K_y { get; set; }

	public int? z { get; set; }

	public AssemblyUnit? AssemblyUnit { get; set; }

	public int? AssemblyUnitKSE { get; set; }
}
