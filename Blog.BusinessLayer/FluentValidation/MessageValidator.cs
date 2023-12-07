using Blog.EntityLayer.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.SenderMail).NotEmpty().WithMessage("E-Posta adresi boş geçilemez");
            RuleFor(x => x.SenderMail).EmailAddress().WithMessage("E-Posta adresi geçerli değil");
            RuleFor(x => x.SenderMail).MaximumLength(50).WithMessage("E-Posta adresi en fazla 50 karakter olmalıdır");

            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("E-Posta adresi boş geçilemez");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("E-Posta adresi geçerli değil");
            RuleFor(x => x.ReceiverMail).MaximumLength(50).WithMessage("E-Posta adresi en fazla 50 karakter olmalıdır");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu en fazla 50 karakter olmalıdır");

            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj boş geçilemez");
            RuleFor(x => x.MessageContent).MaximumLength(1000).WithMessage("Mesaj en fazla 1000 karakter olmalıdır");

        }
    }
}
