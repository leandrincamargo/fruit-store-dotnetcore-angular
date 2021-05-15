using FruitStore.Application.Interfaces.Services;
using System;
using System.Security.Cryptography;
using System.Text;

namespace FruitStore.Application.Services
{
    public class SecurityService: ISecurityService
    {
        public string Encrypt(string value, string salt)
        {
            byte[] byteRepresentation = Encoding.UTF8.GetBytes(value + salt);
            SHA1CryptoServiceProvider mySHA1 = new SHA1CryptoServiceProvider();
            byte[] hashedTextInBytes = mySHA1.ComputeHash(byteRepresentation);
            return Convert.ToBase64String(hashedTextInBytes);
        }
    }
}
