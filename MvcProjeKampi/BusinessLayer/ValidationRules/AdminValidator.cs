using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Kullanıcı E-postası Adı Boş Olamaz!");
            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Açıklama Boş Olamaz!");
            RuleFor(x => x.AdminUserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.AdminUserName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapınız.");
            RuleFor(x => x.AdminRole).MinimumLength(1).WithMessage("Lütfen en az 1 karakter girişi yapınız.");
            RuleFor(x => x.AdminRole).MaximumLength(1).WithMessage("Lütfen en fazla 1 karakter girişi yapınız.");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre Alanı Boş geçilemez");
        }
    }
}
