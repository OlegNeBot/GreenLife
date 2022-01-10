using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace GreenLifeLib
{
    public class Account
    {
        public int Id { get; private set; }
        public string Login { get; private set; }

        private string _password = null;
        public string Password {
            get { return _password; }
            private set { _password = ToHash(value); }
        }
        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public enum Sex
        {
            Male,
            Female,
            Other
        }
        public Sex UserSex { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime RegDate { get; private set; }

        public User User { get; set; }
        public List<UserAnswer> UserAnswer { get; set; }

        public Account() { }

        public Account(int id, string login, string password, string name, string fname, Sex sex, DateTime dOB, DateTime reg) 
        {
            Id = id;
            Login = login;
            Password = password;
            Name = name;
            FamilyName = fname;
            UserSex = sex;
            DateOfBirth = dOB;
            RegDate = reg;
        }

        public static void AddAccount(Account acc)
        {
            using (ApplicationContext db = new())
            {
                db.Account.Add(acc);
                db.SaveChanges();
            }
        }

        public static string ToHash(string pass) 
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] _computed = sha.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var _builder = new StringBuilder();
                for (int i = 0; i < _computed.Length; i++)
                    _builder.Append(_computed[i].ToString("x2"));
                return _builder.ToString();
            }
        }
    }
}
