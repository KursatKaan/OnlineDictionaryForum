using Blog.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori adı en fazla 20 karakter olmalıdır");

            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez");
            RuleFor(x => x.CategoryDescription).MaximumLength(200).WithMessage("Kategori açıklaması en fazla 200 karakter içermelidir");

        }
    }
}

