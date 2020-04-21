using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using WebUI.Models;

namespace WebUI.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator:AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("İsim gerekli!");

            RuleFor(s => s.Email).NotEmpty().WithMessage("E Posta Adresi gerekli!");
            RuleFor(s => s.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("E Posta Adresi hatalı!");
            
            RuleFor(s => s.Age).NotEmpty().WithMessage("Yaş gereklidir!");
            RuleFor(s => s.Age).GreaterThan(18).WithMessage("Yaş 18-65 Arası olmalıdır!");
            RuleFor(s => s.Age).LessThan(65).WithMessage("Yaş 18-65 Arası olmalıdır!");
            
            //RuleFor(s => s.Age).NotEmpty().When(s=>s.Age<65 && s.Age>18).WithMessage("Yaş 18-65 Arası olmalıdır!");
            //RuleFor(s => s.FirstName).Must(StartA).WithMessage("A ile başlamalı!");
        }

        private bool StartA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
