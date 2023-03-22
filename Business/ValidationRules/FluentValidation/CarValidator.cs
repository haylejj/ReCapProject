using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(2);
            RuleFor(p => p.CarName).MaximumLength(35);
            RuleFor(p => p.ModelYear).LessThan(DateTime.Now.Year);
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(10000).When(p=>p.ModelYear>=2020);
        }
    }
}
