using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common.HashText
{
    public class HashText : IHashText
    {
        public string HashPassword(string password)
        {
            string _pepper = "P&0myWHq";
            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(
                Encoding.Unicode.GetBytes(password + _pepper));
                return Convert.ToBase64String(computedHash);
            }
        }
    }
}
