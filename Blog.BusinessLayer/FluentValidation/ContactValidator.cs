using Blog.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim en fazla 50 karakter olmalıdır");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("E-Posta adresi boş geçilemez");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("E-Posta adresi geçerli değil");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("E-Posta adresi en fazla 50 karakter olmalıdır");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu en fazla 50 karakter olmalıdır");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş geçilemez");
            RuleFor(x => x.Message).MinimumLength(30).WithMessage("Mesaj en az 30 karakter içermelidir");
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage("Mesaj en fazla 1000 karakter içermelidir");
        }
    }
}
