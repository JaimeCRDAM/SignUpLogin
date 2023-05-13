using System;
using System.Security.Cryptography;
using System.Text;

namespace SignUpLogin.Models.Security
{
    public class Password
    {
        private const int SaltSize = 16; // Size of the salt in bytes
        private const string Pepper = "JoseAlbertoRules"; // Replace with your pepper value

        public static string HashPassword(string password)
        {
            byte[] salt = GenerateSalt(SaltSize);
            string hashedPassword = ComputeHash(password, salt);
            return FormatPasswordHash(hashedPassword, salt);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            (string storedHash, byte[] storedSalt) = ParsePasswordHash(hashedPassword);
            string computedHash = ComputeHash(password, storedSalt);
            return string.Equals(computedHash, storedHash);
        }

        private static byte[] GenerateSalt(int saltSize)
        {
            byte[] salt = new byte[saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private static string ComputeHash(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] pepperBytes = Encoding.UTF8.GetBytes(Pepper);

            byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length + pepperBytes.Length];

            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);
            Buffer.BlockCopy(pepperBytes, 0, saltedPassword, passwordBytes.Length + salt.Length, pepperBytes.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private static string FormatPasswordHash(string hashedPassword, byte[] salt)
        {
            string saltString = Convert.ToBase64String(salt);
            return $"{hashedPassword}.{saltString}";
        }

        private static (string Hash, byte[] Salt) ParsePasswordHash(string hashedPassword)
        {
            string[] parts = hashedPassword.Split('.');
            string hash = parts[0];
            byte[] salt = Convert.FromBase64String(parts[1]);
            return (hash, salt);
        }
    }
}
