using System.ComponentModel.DataAnnotations;

namespace ChainTransmissionAPI.Models
{
	public class UnitProp
	{
		public required string TN { get; set; }

		public required string TU { get; set; }

		public double K_d { get; set; }
	}
}
