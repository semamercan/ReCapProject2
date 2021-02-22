using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserFirstName).NotEmpty();
            RuleFor(p => p.UserLastName).NotEmpty();
            RuleFor(p => p.UserPassword).NotEmpty();
            RuleFor(p => p.UserEMail).EmailAddress();
            RuleFor(p => p.UserPassword).MinimumLength(5);
        }
    }
}
