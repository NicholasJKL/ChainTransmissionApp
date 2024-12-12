using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChainTransmissionAPI.Models
{
	public class ChainProp
	{
		public required string ND { get; set; }

		[Column("tc")]
		public double Tc { get; set; }

		public double S {  get; set; }
	}
}
