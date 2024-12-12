using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChainTransmissionAPI.Models
{
	public class AssemblyUnitProp
	{
		[Column("tc")]
		public required double Tc { get; set; }

		public required string SM { get; set; }

		[Column("v")]
		public double V { get; set; }
	}
}
