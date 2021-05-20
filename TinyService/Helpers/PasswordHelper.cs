using System.Security.Cryptography;
using System.Text;

namespace TinyService.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (var v in retVal) sb.Append(v.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
