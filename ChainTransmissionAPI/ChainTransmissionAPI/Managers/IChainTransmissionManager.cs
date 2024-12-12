namespace ChainTransmissionAPI.Managers
{
	public interface IChainTransmissionManager
	{
		public Task<string> CalculateUnitVerificationAsync(int unitId);
	}
}
