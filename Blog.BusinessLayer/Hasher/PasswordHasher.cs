using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Hasher
{
    public static class PasswordHasher
    {

        public static string HashPassword(string password)
        {
            // Adım 1: Salt Oluşturma
            //var salt = GenerateSalt(16);

            // Adım 2: Şifreleme
            var hashedPassword = GenerateSHA256(password/*, salt*/);

            // Sonuç olarak hashlenmiş şifreyi döndür
            return hashedPassword;
        }

        private static string GenerateSalt(int size)
        {
            // Salt oluştur
            byte[] buff = new byte[size];
            new RNGCryptoServiceProvider().GetBytes(buff);
            return BitConverter.ToString(buff).Replace("-", "").ToLower();
            //return Convert.ToBase64String(buff);
        }

        private static string GenerateSHA256(string input/*, string salt*/)
        {
            // SHA-256 algoritması kullanarak şifreyi ve salt'ı hashle
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input /*+ salt*/));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
                //return Convert.ToBase64String(hash);
            }
        }


    }
}
