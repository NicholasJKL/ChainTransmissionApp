using Microsoft.EntityFrameworkCore;

namespace ChainTransmissionAPI.Models.Contexts
{
	public class StaticVariablesContext : DbContext
	{
		public DbSet<ChainProp> ChainProps { get; set; } = null!;
		public DbSet<GearProp> GearProps { get; set; } = null!;
		public DbSet<AssemblyUnitProp> AssemblyUnitProps { get; set; } = null!;
		public DbSet<UnitProp> UnitProps { get; set; } = null!;

		public StaticVariablesContext(DbContextOptions<StaticVariablesContext> options)
			: base(options) => Database.EnsureCreated();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ChainProp>()
				.HasKey(chain => new { chain.ND });
			modelBuilder.Entity<GearProp>()
				.HasKey(gear => new { gear.Z, gear.Tc });
			modelBuilder.Entity<UnitProp>()
				.HasKey(unit => new { unit.TN, unit.TU });
			modelBuilder.Entity<AssemblyUnitProp>()
				.HasKey(aup => new { aup.Tc, aup.SM });
		}
	}
}