// refer to: https://www.reddit.com/media?url=https%3A%2F%2Fi.redd.it%2Fkhmewc4cfcyb1.png
// for project details

using GarageCarCapacity.ConsoleResponce;
using GarageCarCapacity.Garage;
using GarageCarCapacity.Utility;

namespace GarageCarCapacity
{
	internal class Program
	{
		private const string carIndicator = "C";
		private const string noCarIndicator = "";

		private static GarageDetails garageDetails;
		private static int maximumCapacity;
		static void Main(string[] args)
		{
			AskUserMaximumGarageCapacity();
			maximumCapacity -= maximumCapacity % 2; // Makes sure inputted value is even
			Console.WriteLine($"Maximum capacity is: {maximumCapacity}.\n" +
				$"If this is different from your inputted value, it is because your " +
				$"value has been rounded down.\n");

			ProptUserOfValidCommands();

			garageDetails = new(maximumCapacity, 0);
			while (true)
			{
				ResponceReturnType _input = GetUserCommand();
				GarageReturnType _return;
				switch (_input) 
				{
					case ResponceReturnType.Enter:
						_return = garageDetails.AddCar();
						if (_return.Equals(GarageReturnType.UnsuccessfullOperation))
						{
							Console.WriteLine("There garage is full.");
							break;
						}
						ShowCurrentGarageCapacity();
						break;
					case ResponceReturnType.Leave:
						_return = garageDetails.RemoveCar();
						if (_return.Equals(GarageReturnType.UnsuccessfullOperation))
						{
							Console.WriteLine("There are no cars left.");
							break;
						}
						ShowCurrentGarageCapacity();
						break;
					case ResponceReturnType.Map:
						ShowGarageMap();
						break;
					case ResponceReturnType.ExitApplication:
						Environment.Exit(-1); // Exits the application
						break;
				}
			}
		}
		private static void ShowCurrentGarageCapacity()
		{
			float _divisedCapacity = 
				garageDetails.currentGarageCapacity / (float)garageDetails.maximumGarageCapacity * 100;
			Console.WriteLine(
				$"Current garage capacity: " +
				$"{RoundingUtility.RoundUpToNearest(_divisedCapacity, 1)}%");
		}
		private static void ShowGarageMap()
		{
			for (int i = 0; i < garageDetails.maximumGarageCapacity; i++)
			{
				string _currentGarageCarIndicator = 
					i < garageDetails.currentGarageCapacity 
					? carIndicator 
					: noCarIndicator;
				switch(i % 10 == 0)
				{
					case true:
						Console.Write($"[{_currentGarageCarIndicator}]\n");
						break;
					case false:
						Console.Write($"[{_currentGarageCarIndicator}]");
						break;
				}
			}
			Console.WriteLine();
		}
		private static ResponceReturnType CheckResponce()
		{
			string _input = Console.ReadLine()!;
			return ConsoleResponceHandler.VerifyResponce(_input);
		}
		private static ResponceReturnType GetUserCommand()
		{
			ResponceReturnType _responceType = CheckResponce();
			while (_responceType.Equals(ResponceReturnType.InvalidResponce)) 
			{
				Console.WriteLine("Unknown command. Here is a list of valid commands:\n");
				ProptUserOfValidCommands();
				_responceType = CheckResponce();
			}
			return _responceType;
		}
		private static void ProptUserOfValidCommands()
		{
			Console.WriteLine(
				"To let a new car enter, type \"Enter\".\n" +
				"To let a car leave the garage type \"Leave\".\n" +
				"To view a map of the garage type \"Map\".\n" +
				"To stop, type \"Exit\".\n");
		}
		private static void AskUserMaximumGarageCapacity()
		{
			int _maximumCapacity = 0;
			while (_maximumCapacity == 0)
			{
				Console.WriteLine("How many cars can the garage hold?");
				if (!int.TryParse(Console.ReadLine(), out int _capacity))
				{
					Console.WriteLine("This is not a number. Try again.");
				}
				_maximumCapacity = _capacity;
			}
			_maximumCapacity = (int)MathF.Floor(_maximumCapacity);
			if(_maximumCapacity < 0)
			{
				Console.WriteLine("Make sure imput is greater than zero.");
			}
			maximumCapacity = _maximumCapacity;
		}
	}
}