﻿using Cibertec.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cibertec.WebApi.Validators
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x =>
            x.FirstName).NotNull().NotEmpty().WithMessage("This field is required");

            RuleFor(x =>
            x.LastName).NotNull().NotEmpty().WithMessage("This field is required");

            RuleFor(x => x.City).NotNull().NotEmpty().WithMessage("This field is required");
        }
    }
}
