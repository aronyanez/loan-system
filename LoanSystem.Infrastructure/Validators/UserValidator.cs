using FluentValidation;
using LoanSystem.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LoanSystem.Infrastructure.Validators
{

    public class UserValidator: AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotNull().NotEmpty();

            RuleFor(user => user.ApprovedAmount)
                .NotNull().NotEmpty();

            RuleFor(user => user.PhoneNumber)
               .NotNull().NotEmpty()
               .Length(10);
        }


    }
}
