using Blog.EntityLayer.Entities;
using FluentValidation;

namespace Blog.BusinessLayer.FluentValidation
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingTitle).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.HeadingTitle).MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır");
            RuleFor(x => x.HeadingTitle).MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olmalıdır");
        }

    }
}
