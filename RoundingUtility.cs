// Source from: https://stackoverflow.com/questions/1329426/how-do-i-round-to-the-nearest-0-5

namespace GarageCarCapacity.Utility
{
	internal static class RoundingUtility
	{
		public static double RoundUpToNearest(double _inputNumber, double _roundTo)
		{
			// 105.5 up to nearest 1 = 106
			// 105.5 up to nearest 10 = 110
			// 105.5 up to nearest 7 = 112
			// 105.5 up to nearest 100 = 200
			// 105.5 up to nearest 0.2 = 105.6
			// 105.5 up to nearest 0.3 = 105.6

			//if no rounto then just pass original number back
			if (_roundTo == 0)
			{
				return _inputNumber;
			}
			else
			{
				return Math.Ceiling(_inputNumber / _roundTo) * _roundTo;
			}
		}
		public static double RoundDownToNearest(double _inputNumber, double _roundTo)
		{
			// 105.5 down to nearest 1 = 105
			// 105.5 down to nearest 10 = 100
			// 105.5 down to nearest 7 = 105
			// 105.5 down to nearest 100 = 100
			// 105.5 down to nearest 0.2 = 105.4
			// 105.5 down to nearest 0.3 = 105.3

			//if no rounto then just pass original number back
			if (_roundTo == 0)
			{
				return _inputNumber;
			}
			else
			{
				return Math.Floor(_inputNumber / _roundTo) * _roundTo;
			}
		}
	}
}
