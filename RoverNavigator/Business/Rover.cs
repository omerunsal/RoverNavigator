using System;
using System.Collections.Generic;
using System.Text;

namespace RoverNavigator
{
	public class Rover
	{
		public int xPosition { get; set; }
		public int yPosition { get; set; }
		public string rotatePosition { get; set; } // East, West, North, South

		public Rover(string location)
		{
			xPosition = Convert.ToInt32(location.Split(" ")[0]);
			yPosition = Convert.ToInt32(location.Split(" ")[1]);
			rotatePosition = location.Split(" ")[2]; 
		}

		public void SpinRight()
		{
			switch (rotatePosition)
			{
				case "N":
					rotatePosition = "E";
					break;
				case "E":
					rotatePosition = "S";
					break;
				case "S":
					rotatePosition = "W";
					break;
				case "W":
					rotatePosition = "N";
					break;
				default:
					throw new Exception(message: "Unvalid route order character! Please check your list.");
			}
		}

		public void SpinLeft()
		{
			switch (rotatePosition)
			{
				case "N":
					rotatePosition = "W";
					break;
				case "E":
					rotatePosition = "N";
					break;
				case "S":
					rotatePosition = "E";
					break;
				case "W":
					rotatePosition = "S";
					break;
				default:
					throw new Exception(message: "Unvalid route order character! Please check your list.");
			}
		}

		public void MoveForward(int[] maxPoints)
		{
			switch (rotatePosition)
			{
				case "N":
					if (yPosition >= maxPoints[1]) { }
					else
						yPosition++;
					break;
				case "E":
					if (xPosition >= maxPoints[0]) { }
					else
						xPosition++;
					break;
				case "S":
					if (yPosition != 0)
						yPosition--;
					else { }

					break;
				case "W":
					if (xPosition != 0)
						xPosition--;
					else { }
					break;
				default:
					throw new Exception(message: "Unvalid route order character! Please check your list.");
			}
		}

		public void MoveToLocation(string routeOrder, int[] maxPoints)
		{
			char[] orders = routeOrder.ToCharArray();

			foreach (var item in orders)
			{
				switch (item)
				{
					case 'L':
						SpinLeft();
						break;
					case 'R':
						SpinRight();
						break;
					case 'M':
						MoveForward(maxPoints);
						break;
					default:
						throw new Exception(message: "Unvalid route order character! Please check your list.");
				}
			}
		}
	}
}
