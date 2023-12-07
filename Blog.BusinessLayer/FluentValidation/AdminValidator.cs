using Blog.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.FluentValidation
{
    public class AdminValidator: AbstractValidator<Admin>
    {
        public AdminValidator() 
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
        }
    }

}
