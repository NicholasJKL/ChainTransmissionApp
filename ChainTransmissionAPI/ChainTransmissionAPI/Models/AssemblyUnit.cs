using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChainTransmissionAPI.Models;

public class AssemblyUnit
{
	[Key]
	public int KSE { get; set; }

	public int? number { get; set; }

	public string TSE { get; set; } = null!;

	public double? delta { get; set; }

	public int? j { get; set; }

	public double? p { get; set; }

	public double? p_critical { get; set; }

	public double F { get; set; }

	public double t { get; set; }

	public double K_T { get; set; }

	public double? s { get; set; }

	public string NSE { get; set; } = null!;

	public int? UnitKU { get; set; }

	public Unit? Unit { get; set; }

	public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
