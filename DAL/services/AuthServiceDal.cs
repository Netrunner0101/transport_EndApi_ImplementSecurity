using DAL.data;
using DAL.models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.services
{
    public class AuthServiceDal
    {

        public string _cnstr;


        public AuthServiceDal( string cnstr)
        {
            _cnstr = cnstr;
        }

        public void Create(UserDal newUser)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                try
                {
                    db.user?.Add(newUser);
                    db.SaveChanges();
                }
                catch
                {
                    throw new Exception("Failed, user not created.");
                }
            }
        }

        public UserDal GetDetailsByEmail(string email)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                try
                {
                    UserDal userEmail = db.user?.Where(u => u.email == email).FirstOrDefault();
                    return userEmail;
                }
                catch
                {
                    throw new Exception("Failed, user not found with email: " + email);
                }
            }
        }




        /*        private void CreatePasswordHash(UserDal newUser, out byte[] passwordHash, out byte[] passwordSalt)
                {
                    try
                    {
                        using (ApplicationDbContext db = new ApplicationDbContext())
                        {
                            using (var hmac = new HMACSHA512())
                            {
                                var userName = newUser.userName;

                                var userEmail = newUser.email;

                                var userPassword = newUser.password;

                                // Create sql insert variable

                                var userNameSql = new SqlParameter("@userName", userName); ;

                                var userEmailSql = new SqlParameter("@email", userEmail); ;

                                var userPasswordSql = new SqlParameter("@password", userPassword); ;

                                passwordSalt = hmac.Key;

                                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userPassword));

                                var passwordSaltSql = new SqlParameter("@passwordHash", passwordSalt);

                                var passwordHashSql = new SqlParameter("@passwordSalt", passwordHash);

                                var commandText = " INSERT INTO [dbo].[user] ([userName] ,[email] ,[password],[passwordHash],[passwordSalt]) VALUES(@userName,@email,@password,@passwordHash,@passwordSalt) ;";

                                db.Database.ExecuteSqlRaw(commandText, userNameSql, userEmailSql, userPasswordSql, passwordSaltSql, passwordHashSql);

                                db.SaveChanges();
                            }
                        }
                    }
                    catch 
                    {
                        throw new Exception("Error by creating user.");
                    }

                }*/

        public void Delete(string email)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var user = db.user?.Where(u => u.email == email).FirstOrDefault();
                if (user != null)
                {
                    db.user?.Remove(user);
                }
            }
        }

        public IEnumerable<UserDal> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                IEnumerable<UserDal> userList = db.user?.ToList();
                return userList;
            }
        }

        public UserDal GetByEmail(string email)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
/*                UserDal userAccount = db.user?.FirstOrDefault(ua => ua.email == email);
*/
                UserDal? userAccount = db.user?.Where(ua => ua.email == email).FirstOrDefault();

                return userAccount;
            }
        }



        /// <summary>
        /// CHECK If User Exist send back the user model is a Boolean 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>


        public bool checkEmail(string email)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                UserDal userAccount = db.user?.FirstOrDefault(ua => ua.email == email);
                if(userAccount !=  null)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Error , Email incorrect");
                }
            }
        }

        /// <summary>
        /// CHECK User password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool checkPassword( string email,  string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                UserDal userAccount = db.user?.FirstOrDefault(ua => ua.email == email);
                if (userAccount != null)
                {

                    var passwordEnter = userAccount.password;
                    var salt = userAccount.passwordSalt;
                    var passwordDatabase = userAccount.passwordHash;
                   /* var passwordDecoded = Crypto.Has*/

                    // Check password
                    using (var hmac = new HMACSHA512(salt))
                    {
                        var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                        var result = computeHash.SequenceEqual(salt);
                        if( result == true)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                }
                // Password Fail
                else
                {
                    throw new Exception(" Error , Password incorrect");
                }
            }
        }

        

        /// <summary>
        ///  If All is true , create a à new token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
/*        private string CreateTokenAuth(UserDal user)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                try
                {
                    // The information in token but also role
                    List<Claim> claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.userName),
                                new Claim(ClaimTypes.Role,"Admin")
                            };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                        _configuration.GetSection("AppSettings:Token").Value
                    ));
                    // Put the credentials
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                    var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: credentials);
                    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                    return jwt;
                }
                catch
                {
                    throw new Exception("Failed, customer not added.");
                }

            }
        }*/


        private bool VerifyPassordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                try
                {
                    using (var hmac = new HMACSHA512(passwordSalt))
                    {
                        var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                        return computeHash.SequenceEqual(passwordHash);
                    }
                }
                catch
                {
                    throw new Exception("Failed, customer not added.");
                }
            }
        }


/*            /// <summary>
            /// genere le sel ! 
            /// </summary>
            /// <returns></returns>
            public  byte[] GenerateSalt()
            {

                byte[] salt = new byte[128 / 8];

                using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(salt);
                }
                return salt;
            }

            /// <summary>
            /// ash le mdp 
            /// </summary>
            /// <param name="salt"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            public string HashPassword(byte[] salt, string password)
            {
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 100000,
                    numBytesRequested: 512 / 8
                    ));

                return hashed;
            }*/

        /*
                private string CreateTokenAuth(UserDal user )
                {
                    using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
                    {
                        try
                        {
                            // The information in token but also role
                            List<Claim> claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.userName),
                                new Claim(ClaimTypes.Role,"Admin")
                            };

                            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                                _configuration.GetSection("AppSettings:Token").Value
                            ));
                            // Put the credentials
                            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                            var token = new JwtSecurityToken(
                                claims: claims,
                                expires: DateTime.Now.AddDays(1),
                                signingCredentials: credentials);
                            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                            return jwt;
                        }
                        catch
                        {
                            throw new Exception("Failed, customer not added.");
                        }

                    }
                }

                private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
                {

                    using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
                    {
                        try
                        {
                             using (var hmac = new HMACSHA512())
                            {
                                passwordSalt = hmac.Key;
                                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                            }
                        }
                        catch
                        {
                            throw new Exception("Failed, customer not added.");
                        }

                    }

                }

                private bool VerifyPassordHash(string password, byte[] passwordHash, byte[] passwordSalt)
                {
                    using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
                    {
                        try
                        {
                            using (var hmac = new HMACSHA512(passwordSalt))
                            {
                                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                                return computeHash.SequenceEqual(passwordHash);
                            }
                        }
                        catch
                        {
                            throw new Exception("Failed, customer not added.");
                        }
                    }
                }*/

    }
}
