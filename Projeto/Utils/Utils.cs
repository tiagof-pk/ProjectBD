using System;
namespace Utils
{
    public class Global
    {
        public static class SecurityHelper
        {
            public static string GenerateSalt(int length = 10)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var random = new Random();
                var salt = new char[length];

                for (int i = 0; i < length; i++)
                    salt[i] = chars[random.Next(chars.Length)];

                return new string(salt);
            }

            public static string HashPassword(string password, string salt)
            {
                using (SHA256 sha = SHA256.Create())
                {
                    var combined = Encoding.UTF8.GetBytes(password + salt);
                    var hash = sha.ComputeHash(combined);
                    return Convert.ToBase64String(hash);
                }
            }
        }
    }
}

