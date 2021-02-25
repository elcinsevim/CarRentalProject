using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rentals>
    {
        public RentalValidator()
        {


            RuleFor(c => c.RentDate).NotEmpty();
            RuleFor(c => c.ReturnDate).NotEmpty();
            RuleFor(r => r.ReturnDate).GreaterThan(DateTime.Now);

        }
    }
}