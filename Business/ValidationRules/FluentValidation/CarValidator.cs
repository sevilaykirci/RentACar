using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator <Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(100);
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.BrandId == 1);
            
            //RuleFor(p => p.ModelYear).Must(StartWith2);
        }

        //private bool StartWith2(short arg)
        //{
        //    return arg.StartsWith(2);
        //}
    }
}
