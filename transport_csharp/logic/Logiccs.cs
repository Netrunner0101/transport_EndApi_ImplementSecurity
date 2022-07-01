using DAL.data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace transport_csharp.logic
{
    public class Logiccs
    {

        private bool VerifyPassordHash(string email, string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var SqlEmail = new SqlParameter("@email", email);

                // retrouver password

                var passwordSql = "SELECT [password] FROM[dbo].[user] WHERE [email] = @email";

                // Retrouver passwordhash

                var paswordhashSql = "SELECT [passwordHash] FROM[dbo].[user] WHERE [email] = @email";

                // retrouver passwordsalt

                var paswordsaltSql = "SELECT [passwordSalt] FROM[dbo].[user] WHERE [email] = @email";

                // Execute the query
                db.Database.ExecuteSqlRaw(passwordSql, paswordhashSql, paswordsaltSql, SqlEmail);

                byte[] hash = Encoding.ASCII.GetBytes(paswordhashSql);

                byte[] salt = Encoding.ASCII.GetBytes(paswordsaltSql);

                using (var hmac = new HMACSHA512(salt))
                {
                    var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordSql));
                    return computeHash.SequenceEqual(hash);
                }
            }
        }

        /// <summary>
        ///  Hash Creation
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private void CreatePasswordHash(string email, string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                using (var hmac = new HMACSHA512())
                {
                    var emailSql = new SqlParameter("@email", email);

                    passwordSalt = hmac.Key;

                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                    var passwordSaltSql = new SqlParameter("@passwordHash", passwordSalt);

                    var passwordHashSql = new SqlParameter("@passwordSalt", passwordHash);

                    var commandText = " UPDATE [dbo].[user] SET [passwordHash] = @passwordHash ,[passwordSalt] = @passwordSalt WHERE [email] = @email";

                    db.Database.ExecuteSqlRaw(commandText, emailSql, passwordSaltSql, passwordHashSql);

                    db.SaveChanges();
                }
            }
        }

    }
}
