using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Abstract
{
    public interface IAdminService
    {
        Admin GetAdminByUserName(string userName);
        bool ValidateAdmin(string userName, string password);

    }
}
