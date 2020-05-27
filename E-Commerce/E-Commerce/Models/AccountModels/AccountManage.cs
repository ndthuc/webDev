using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace E_Commerce.Models.AccountModels
{
    public class AccountManage
    {
        Model1 db = new Model1();
        public bool CheckEmail(string NewEmail)
        {
            User user = db.Users.Where(us => us.Email == NewEmail).FirstOrDefault();
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckUserName(string UserName)
        {
            User user = db.Users.Where(us => us.Account == UserName).FirstOrDefault();
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckPhonenumber(string Phone)
        {
            User user = db.Users.Where(us => us.PhoneNumber == Phone).FirstOrDefault();
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckUserLogin(LoginModel login)
        {
            login.Password = EncryptedPassword(login.Password);
            User user = db.Users.Where(us => us.Account == login.UserName
            && us.Password == login.Password).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string EncryptedPassword(string Password)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(Password);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }
    }
}