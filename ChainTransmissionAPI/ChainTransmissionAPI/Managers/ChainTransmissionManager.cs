using ChainTransmissionAPI.Models;
using ChainTransmissionAPI.Models.Contexts;
using System.Linq.Expressions;


namespace ChainTransmissionAPI.Managers
{
	public class ChainTransmissionManager : IChainTransmissionManager
	{
		private readonly ChainTransmissionContext _dbCT;
		private readonly StaticVariablesContext _dbSV;

		public ChainTransmissionManager(ChainTransmissionContext ctContext, StaticVariablesContext svContext)
		{
			_dbCT = ctContext;
			_dbSV = svContext;
		}

		public double GetK_m(string VD)
		{
			switch (VD)
			{
				case ("Однорядная"):
					return 1;
				case ("Двухрядная"):
					return 1.7;
				case ("Трёхрядная"):
					return 2.5;
				case ("Четырёхрядная"):
					return 3.0;
				default:
					return -1;
			}
		}

		public double CalculateP(Unit unit, AssemblyUnitProp auProp, UnitProp unitProp, Part chain, ChainProp chainProp)
		{
			double F = 1000 * unit.N * auProp.V;
			double p = (F * unitProp.K_d) / (chainProp.S * GetK_m(chain.VD ?? ""));

			if (p < 0)
			{
				throw new Exception("Invalid parameters");
			}
			return p;
		}

		public double CalculatePCritical(AssemblyUnit au, GearProp gearProp, ChainProp chainProp)
		{
			double K_z = Math.Pow(gearProp.Z, 1.0 / 12.0);
			double K_T = Math.Pow((15 * 1000) / au.t, 1.0 / 4.0);
			double K_y = 10 * (Math.Pow(gearProp.N / 10, 1.0 / 9.0));
			double K_t = chainProp.Tc <= 25.4 ?
				Math.Pow(chainProp.Tc / 25.4, 1.0 / 6.0) :
				Math.Pow(chainProp.Tc / 25.4, 1.0 / 24.0);
			double pCritical = (270 * K_z * K_T) / (K_y * K_t);
			Console.WriteLine($"K_z: {K_z}");
			Console.WriteLine($"K_T: {K_T}");
			Console.WriteLine($"K_y: {K_y}");
			Console.WriteLine($"K_t: {K_t}");
			return pCritical;
		}

		public async Task<string> CalculateUnitVerificationAsync(int unitId)
		{
			try
			{
				Unit? unit = await _dbCT.Units.FindAsync(unitId) ??
				throw new Exception("Cannot find unit with current id");

				AssemblyUnit[] assemblyUnits = [.. unit.AssemblyUnits];

				foreach (AssemblyUnit assemblyUnit in assemblyUnits)
				{
					Part[] parts = assemblyUnit.Parts.ToArray() ??
						throw new Exception("Cannot find parts");

					Part[] chains = parts.Where(part => part.ND.Contains("ПР")).ToArray();

					if (chains.Length != 1)
					{
						throw new Exception("Cannot find a chain or there are more than one chain");
					}

					Part chain = chains[0];

					ChainProp chainProp = await _dbSV.ChainProps.FindAsync(chain.ND) ??
						throw new Exception("Cannot find the chain with specific parameters");

					AssemblyUnitProp auProp = await _dbSV.AssemblyUnitProps.FindAsync([chainProp.Tc, assemblyUnit.SM]) ??
						throw new Exception("Cannot find the assembly unit parameters");

					UnitProp unitProp = await _dbSV.UnitProps.FindAsync([unit.TN, unit.TU]) ??
						throw new Exception("Cannot find the unit parameters");

					Part[] mainGears = parts.Where(part => part.NaD == "Ведущее").ToArray();

					if (mainGears.Length != 1)
					{
						throw new Exception("Cannot find a main gear or there are more than one main gear");
					}
					Part mainGear = mainGears[0];

					GearProp gearProp = await _dbSV.GearProps.FindAsync([mainGear.z, chainProp.Tc]) ??
						throw new Exception("Cannot find the gear parameters");

					double p = CalculateP(unit, auProp, unitProp, chain, chainProp);

					double pCritical = CalculatePCritical(assemblyUnit, gearProp, chainProp);

					double delta = pCritical - p;

					assemblyUnit.s = delta >= 0 ? "Допустимо" : "Недопустимо";
				}
			}

			catch (Exception ex)
			{
				return ex.Message;
			}
			await _dbCT.SaveChangesAsync();

			return "";
		}
	}
}
