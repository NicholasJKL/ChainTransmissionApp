using Microsoft.EntityFrameworkCore;


namespace ChainTransmissionAPI.Models
{
	public class ChainTransmissionContext : DbContext
	{
		public DbSet<Unit> Units { get; set; } = null!;
		public DbSet<AssemblyUnit> AssemblyUnits { get; set; } = null!;
		public DbSet<Part> Parts { get; set; } = null!;

		public ChainTransmissionContext(DbContextOptions<ChainTransmissionContext> options)
			: base(options) => Database.EnsureCreated();
	}
}
