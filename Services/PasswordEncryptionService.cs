using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace InterviewTask_Dotnet.Services
{
    public class PasswordEncryptionService
    {
            public string Encrypt(string plainText)
        {
            var bytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(bytes);
        }

        public string Decrypt(string base64Encoded)
        {
            var bytes = Convert.FromBase64String(base64Encoded);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}