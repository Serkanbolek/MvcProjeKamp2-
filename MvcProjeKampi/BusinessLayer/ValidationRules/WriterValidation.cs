using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidation : AbstractValidator<Writer>
    {
        public WriterValidation()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Olamaz!");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Soyadı Boş Olamaz!");
            RuleFor(x => x.WriteAbout).NotEmpty().WithMessage("Hakkında Boş Olamaz!");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız.");
        }
    }
}
