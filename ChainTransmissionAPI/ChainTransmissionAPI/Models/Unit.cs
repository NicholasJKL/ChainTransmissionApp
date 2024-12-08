using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChainTransmissionAPI.Models;

public class Unit
{
	[Key]
	public int KU { get; set; }

	public string NU { get; set; } = null!;

	public string TU { get; set; } = null!;

	public string VU { get; set; } = null!;

	public int i { get; set; }

	public double N { get; set; }

	public virtual ICollection<AssemblyUnit> AssemblyUnits { get; set; } = new List<AssemblyUnit>();
}
