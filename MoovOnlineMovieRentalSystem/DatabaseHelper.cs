using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace MoovOnlineMovieRentalSystem
{
    public static class DatabaseHelper
    {
        // replace connectionString
        private static string connectionString = "Data source = ARYANSROG\\SQLEXPRESS; Initial Catalog = MoovRentalDB; Integrated Security = True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

    public static class AuthenticationHelper
    {
        public static string GenerateSalt()
        {
            var saltBytes = new byte[16];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
