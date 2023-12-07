using Blog.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.FluentValidation
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutDetails1).MaximumLength(1000).WithMessage("Hakkımızda alanı en fazla 1000 karakter olmalıdır");
        }

    }
}
