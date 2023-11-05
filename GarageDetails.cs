namespace GarageCarCapacity.Garage
{
	internal struct GarageDetails
	{
		public int maximumGarageCapacity { get; set; }
		public int currentGarageCapacity { get; set; }

		public GarageDetails(int _maximumGarageCapacity, int _currentGarageCapacity)
		{
			maximumGarageCapacity = _maximumGarageCapacity;
			currentGarageCapacity = _currentGarageCapacity;
		}
		public GarageReturnType AddCar()
		{
			int _returnValue = currentGarageCapacity < maximumGarageCapacity ? 1 : 0;
			currentGarageCapacity += _returnValue;
			return (GarageReturnType)_returnValue;
		}
		public GarageReturnType RemoveCar()
		{
			int _returnValue = currentGarageCapacity > 0 ? 1 : 0;
			currentGarageCapacity -= _returnValue;
			return (GarageReturnType)_returnValue;
		}
	}
}
