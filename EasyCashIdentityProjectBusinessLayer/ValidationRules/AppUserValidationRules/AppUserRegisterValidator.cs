using EasyCashIdentityProjectDtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProjectBusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez..");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez..");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez..");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez..");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez..");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Doğrulama Şifresi alanı boş geçilemez..");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriş yapın.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriş yapın.");
            RuleFor(x => x.ConfirmPassword).Equal(y=>y.Password).WithMessage("Parolanız eşleşmiyor.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçeli bir email adresi geçiniz.");

        }
    }
}
