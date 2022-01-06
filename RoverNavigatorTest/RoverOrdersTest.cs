using RoverNavigator;
using System;
using Xunit;

namespace RoverNavigatorTest
{
	public class RoverOrdersTest
	{
		int[] maxPoints = new int[] { 6, 6 };

		[Fact]
		public void SpinLeft()
		{
			Rover rover = new Rover("0 2 W");
			rover.SpinLeft();
			Assert.Equal("S", rover.rotatePosition);
		}

		[Fact]
		public void SpinRight()
		{
			Rover rover = new Rover("0 2 W");
			rover.SpinRight();
			Assert.Equal("N", rover.rotatePosition);
		}
		[Fact]
		public void MoveForward()
		{
			Rover rover = new Rover("0 2 W");
			rover.MoveForward(maxPoints);
			Assert.Equal(0, rover.xPosition);
		}

		[Fact]
		public void MoveToLocation()
		{
			Rover rover = new Rover("0 2 W");
			rover.MoveToLocation("MMMRMMMM", maxPoints);
			Assert.Equal("0 6 N", rover.xPosition + " " + rover.yPosition + " " + rover.rotatePosition);
		}

	}
}
