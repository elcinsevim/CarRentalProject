using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public  class CarsImagesValidator: AbstractValidator<CarImage>
    {
        public CarsImagesValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.CarId).GreaterThan(0);
        }
    }
}

