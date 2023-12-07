using Blog.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.FluentValidation
{
    public class ContentValidator  : AbstractValidator<Content>
    {
        public ContentValidator()
        {
            
            RuleFor(x => x.ContentText).MaximumLength(1000).WithMessage("İçerik en fazla 1000 karakter olmalıdır");
        }
    }
}
