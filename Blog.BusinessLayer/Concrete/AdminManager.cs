using Blog.BusinessLayer.Abstract;
using Blog.BusinessLayer.Hasher;
using Blog.DataLayer.Abstract;
using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        protected IAdminDal _adminDal;

        //Constructor
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }


        public Admin GetAdminByUserName(string userName)
        {
            return _adminDal.GetOne(x => x.AdminUserName == userName);
        }

        public bool ValidateAdmin(string userName, string password)
        {
            Admin admin = GetAdminByUserName(userName);
            if (admin != null)
            {
                // Parola doğrulama
                string hashedEnteredPassword = PasswordHasher.HashPassword(password);
                return hashedEnteredPassword == admin.AdminPassword;

            }

            return false;
        }

    }
}
