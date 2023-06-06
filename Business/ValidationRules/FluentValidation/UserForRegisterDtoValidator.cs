﻿using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.FirstName).MaximumLength(50);

            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.LastName).MaximumLength(50);

            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).NotEmpty();

            RuleFor(u => u.Password).NotNull();
            RuleFor(u => u.Password).NotEmpty();



        }
    }
}
