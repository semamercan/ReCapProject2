﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator :AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(p => p.CarImageId).NotEmpty();
            RuleFor(p => p.CarId).NotEmpty();
        }
    }
}
