namespace GarageCarCapacity.ConsoleResponce
{
	internal static class ConsoleResponceHandler
	{
		public static ResponceReturnType  VerifyResponce(string input)
		{
			switch (input.ToLower())
			{
				case "enter":
					return ResponceReturnType.Enter;
				case "leave":
					return ResponceReturnType.Leave;
				case "map":
					return ResponceReturnType.Map;
				case "exit":
					return ResponceReturnType.ExitApplication;
				default:
					return ResponceReturnType.InvalidResponce;
			}
		}
	}
}
