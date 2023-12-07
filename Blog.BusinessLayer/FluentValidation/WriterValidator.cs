using Blog.EntityLayer.Entities;
using FluentValidation;

namespace Blog.BusinessLayer.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Yazar adı en az 3 karakter olmalıdır");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Yazar adı en fazla 50 karakter olmalıdır");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Yazar soyadı en az 3 karakter olmalıdır");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Yazar soyadı en fazla 50 karakter olmalıdır");

            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkımda alanı boş geçilemez");
            RuleFor(x => x.About).MinimumLength(10).WithMessage("Hakkımda alanı en az 10 karakter olmalıdır");
            RuleFor(x => x.About).MaximumLength(200).WithMessage("Hakkımda alanı en fazla 200 karakter içermelidir");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("E-posta boş geçilemez");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("E-posta formatı uygun değil.");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("E-posta adresi en fazla 50 karakter olmalıdır");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter içermelidir");
            RuleFor(x => x.Password).MaximumLength(64).WithMessage("Şifre en fazla 64 karakter olmalıdır");

            RuleFor(x => x.Level).NotEmpty().WithMessage("Yazar seviyesi boş geçilemez");

        }
    }
}

