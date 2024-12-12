using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChainTransmissionAPI.Models
{
	public class GearProp
	{
		[Column("z")]
		public required int Z {  get; set; }

		[Column("tc")]
		public required double Tc { get; set; }

		public double N { get; set; }
	}
}
