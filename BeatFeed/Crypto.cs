using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeedProject3
{
    public static class Crypto
    {
        public static string MD5(string value)
        {
            return Convert.ToBase64String(System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value)));
        }

        public static string SHA1(string value)
        {
            var sha1 = new System.Security.Cryptography.SHA1Managed();
            var plainTextBytes = Encoding.UTF8.GetBytes(value);
            var hashBytes = sha1.ComputeHash(plainTextBytes);
            var sb = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                sb.AppendFormat("{0:x2}", hashByte);
            }
            return sb.ToString();
        }
    }
}
