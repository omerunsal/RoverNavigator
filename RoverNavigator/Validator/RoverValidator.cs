using FluentValidation;
using RoverNavigator;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverNavigatorBusiness.Validator
{
	public class RoverValidator : AbstractValidator<Rover>
	{
		public RoverValidator()
		{
			RuleFor(p => p.xPosition).NotNull().WithMessage("Please ensure that you have entered your x position");
			RuleFor(p => p.yPosition).NotNull().WithMessage("Please ensure that you have entered your y position");
			RuleFor(p => p.rotatePosition).NotNull().WithMessage("Please ensure that you have entered your rotate position");
		}
	}
}
