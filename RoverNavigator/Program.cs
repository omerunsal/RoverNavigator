using FluentValidation.Results;
using RoverNavigatorBusiness.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RoverNavigator
{
	class Program
	{
		static void Main(string[] args)
		{

			/// <summary>
			/// Validator instance for rover's infos
			/// </summary>
			RoverValidator roverValidator = new RoverValidator();

			List<string> numberStrList = new List<string> { "0123456789" };
			List<string> orderList = new List<string> { "RLM" };



			Console.WriteLine("Welcome..\nHere is correct input example:\n 5 5\n 1 2 N\n LMLMLMLMM\n 3 3 E\n MMRMMRMRRM\n");
			Console.WriteLine("****************************************************************************************");


			/// <summary>
			/// Inputs
			/// </summary>
			var maxPointsWOSplit = Console.ReadLine();
			var maxPoints = maxPointsWOSplit.Split(' ');

			var isLimitInputValid = Regex.IsMatch(maxPointsWOSplit, @"\d");

			var firstRovCurrentLocation = Console.ReadLine().Split(' ');
			var firsRovMovementOrder = Console.ReadLine();

			var secRovCurrentLocation = Console.ReadLine().Split(' ');
			var secRovMovementOrder = Console.ReadLine();


			#region Validation

			firsRovMovementOrder = firsRovMovementOrder.ToUpper();
			secRovMovementOrder = secRovMovementOrder.ToUpper();

			if (!firsRovMovementOrder.Where(x => x == 'M' || x == 'R' || x == 'L').Any())
			{
				Console.WriteLine("First rover order input is incorrect format. Please check it.");
				Console.ReadLine();
				Environment.Exit(0);
			}
			if (!secRovMovementOrder.Where(x => x == 'M' || x == 'R' || x == 'L').Any())
			{
				Console.WriteLine("First rover order input is incorrect format. Please check it.");
				Console.ReadLine();
				Environment.Exit(0);
			}

			#endregion

			#region BusinessRules

			if (maxPoints.Length > 2)
			{
				Console.WriteLine("Limit Length can not bigger than 2. Try Again..");
				Console.ReadLine();
				Environment.Exit(0);


			}
			else if (maxPoints.Length < 2)
			{
				maxPoints = new string[] { "0", "0" };
			}

			if (isLimitInputValid == false)
			{
				Console.WriteLine("Limit Input can be numeric char. Try Again..");
				Console.ReadLine();
				Environment.Exit(0);

			}
			if (maxPoints.Where(x => int.Parse(x) < 0).Any())
			{
				Console.WriteLine("Limit Input can be positive number. Try Again..");
				Console.ReadLine();
				Environment.Exit(0);
			}

			int[] intMaxPoints = Array.ConvertAll(maxPoints, s => int.Parse(s));


			#endregion


			/// <summary>
			/// Execution of order entries of 2 rovers
			/// </summary>
			Rover firstRover = new Rover(firstRovCurrentLocation[0] + " " + firstRovCurrentLocation[1] + " " + firstRovCurrentLocation[2].ToUpper());
			ValidationResult res = roverValidator.Validate(firstRover);
			if (res.Errors.Count == 0)
			{
				firstRover.MoveToLocation(firsRovMovementOrder, intMaxPoints);
			}
			else
			{
				Console.WriteLine(res.Errors);
			}

			Rover secRover = new Rover(secRovCurrentLocation[0] + " " + secRovCurrentLocation[1] + " " + secRovCurrentLocation[2].ToUpper());
			ValidationResult resSec = roverValidator.Validate(secRover);
			if (resSec.Errors.Count == 0)
			{
				secRover.MoveToLocation(secRovMovementOrder, intMaxPoints);
			}
			else
			{
				Console.WriteLine(res.Errors);
			}


			Console.WriteLine(firstRover.xPosition + " " + firstRover.yPosition + " " + firstRover.rotatePosition + "\n" + secRover.xPosition + " " + secRover.yPosition + " " + secRover.rotatePosition);
		}
	}
}
