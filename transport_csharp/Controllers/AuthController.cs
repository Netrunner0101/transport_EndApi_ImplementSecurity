﻿using BLL.services;
using DAL.data;
using DAL.models;
using entity_jwt_aspnetcore.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using transport_csharp.mapper;
using transport_csharp.modelsDto;

namespace entity_jwt_aspnetcore.Controllers
{
    [ApiController]
    [Route("tms")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        public static UserApiModel user = new UserApiModel();

        public readonly IConfiguration _configuration;

        public readonly AuthServiceBll _authService;

        public readonly JwtSettings _jwtSettings;

        public AuthController(IConfiguration configuration, AuthServiceBll authService , JwtSettings jwtsettings)
        {
            _configuration = configuration;
            _authService = authService;
            _jwtSettings = jwtsettings;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserApiModel>> RegisterUser([FromBody] UserApiModel requestUser)
        {
            try
            {
                // 1) First create user
                _authService.CreateUser(requestUser.ToBll());

                string emailRequest = requestUser.email;
                string passwordRequest = requestUser.password;

                // 2) Then create passwordhash
                CreatePasswordHash(emailRequest, passwordRequest, out byte[] passwordHash, out byte[] passwordSalt);

                requestUser.passwordHash = passwordHash;

                requestUser.passwordSalt = passwordSalt;

                return Ok(requestUser);
            }
            catch
            {
                return BadRequest(" Error, User cannot be create .");
            }  
        }

        /// <summary>
        ///  Get user by email 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("user/email/{email}")]
        public async Task<ActionResult<UserApiModel>> GetUserByEmail(string email)
        {
            try
            {
                // Search by user
                UserApiModel specificUser = _authService.GetUserDetailsByEmail(email).ToApi();

                return Ok(specificUser);
            }
            catch
            {
                return BadRequest(" Error, User not found by email: "+email);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLogin requestUser)
        {
            string? userCheckMail = searchEmail(requestUser.email);

            if (userCheckMail == null)
            {
                return BadRequest("User not found" + "  user email  " + userCheckMail + "  login email  " + requestUser.email + " Password "+requestUser.password);
            }

            /*byte[] passwordHashUser = searchHash(userCheckMail);

            byte[] passwordHashSalt = searchSalt(userCheckMail);

            if (!VerifyPassordHash(requestUser.email, requestUser.password, passwordHashUser, passwordHashSalt))
            {
                return BadRequest("Error , Wrong password" + "  " + requestUser.email + "  " + requestUser.password + "  " + passwordHashUser + "  " + passwordHashSalt + " " + VerifyPassordHash(requestUser.email, requestUser.password, passwordHashUser, passwordHashSalt));
            }*/

            /*UserToken userTok = new UserToken();

              userTok.email = requestUser.email;

              userTok.password = requestUser.password;

              UserToken token = CreateToken(userTok, _jwtSettings);*/


            UserApiModel userJwt = searchUserApiModel(userCheckMail);

            string jwtCreation = CreateToken(userJwt, _jwtSettings);

            // Creation de token
            // not just jwtCreation but new token
            // Be carefurl !! Return JSON WITH "token" JUST Take the token not the string
            
            return Ok(new { token= jwtCreation });

        }

        private string CreateToken(UserApiModel userApi, JwtSettings jwtSettings)
        {
            try
            {
                UserToken usertoken = new UserToken();
                /*              
                List<Claim> claims = new List<Claim>();
                {
                    new Claim(ClaimTypes.Email, userToken.email); 
                }*/

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(

                    // ATTENTION ! Token get section is in app.json file
                    _configuration.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512);

                var token = new JwtSecurityToken(
                    claims: new Claim[]{
                         new Claim(ClaimTypes.Email, value: userApi.email),
                         new Claim(ClaimTypes.Role, value: "Dispatcher"),
                    },
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

                return ( new JwtSecurityTokenHandler().WriteToken(token) ); 
            }
            catch (Exception ex)
            {
                throw (ex );
            }
        }

        /// <summary>
        ///  Create Token Alex Version
        /// </summary>
        /// <param name="user"></param>
        /// <param name="jwtSettings"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
    /*    private UserToken CreateToken2(UserToken user, JwtSettings jwtSettings)
        {
            try
            {
                UserToken UserToken = new UserToken();
                if (user == null) throw new ArgumentNullException("user not exist");
                byte[] key = Encoding.ASCII
                    .GetBytes(jwtSettings.IssuerSignInKey);
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.userName),
                            new Claim("Admin",user.isAdmin.ToString(),ClaimValueTypes.Boolean),
                            //new Claim(ClaimTypes.Role,"Admin")
                        },
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials
                    (
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256
                    )

                    );

                UserToken.token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                UserToken.isAdmin = user.isAdmin;

                return UserToken;
            }
            catch
            {
                throw new Exception("Error token ");
            }
        }
*/
        private void CreatePasswordHash(string email,string password, out byte[] passwordHash, out byte[] passwordSalt)
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

        private string? searchEmail(string email)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var commandText = "SELECT [email] FROM[dbo].[user] WHERE [email] = @email";

                return (string?) db.executeScalar(commandText, new {email = email} );
            }
        }

       private UserApiModel searchUserApiModel(string email)
       {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                UserApiModel user = _authService.GetUser(email).ToApi();

                return user;
            }
       }

        private byte[] searchSalt(string email)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var commandText = "SELECT [passwordSalt] FROM[dbo].[user] WHERE [email] = @email";

                /*byte[] result = (byte[])db.executeScalar(commandText, new { email = email });*/

                /* byte[] salt = Encoding.ASCII.GetBytes(result);*/

                /* return (byte[])db.executeScalar(commandText, new { email = email });*/

                return (byte[])db.executeScalar(commandText, new { email = email });
            }
        }

        private byte[] searchHash(string email)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var commandText = "SELECT [passwordHash] FROM[dbo].[user] WHERE [email] = @email";
/*
                byte[] result = (byte[])db.executeScalar(commandText, new { email = email });*/

                /*  byte[] salt = Encoding.ASCII.GetBytes(result);*/

                /*return result;*/

                /* return (byte[])db.executeScalar(commandText, new { email = email });*/

                return (byte[])db.executeScalar(commandText, new { email = email });
            }
        }

        private bool VerifyPassordHash(string email, string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                using (var hmac = new HMACSHA512(passwordSalt))
                {
                    var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return computeHash.SequenceEqual(passwordHash);
                }

                /*var SqlEmail = new SqlParameter("@email", email);*/

                // retrouver password

                /*var passwordSql = "SELECT [password] FROM[dbo].[user] WHERE [email] = @email";*/

                // Retrouver passwordhash

                /*var paswordhashSql = "SELECT [passwordHash] FROM[dbo].[user] WHERE [email] = @email";*/

                // retrouver passwordsalt

                /*var paswordsaltSql = "SELECT [passwordSalt] FROM[dbo].[user] WHERE [email] = @email";*/

                // Execute the query
                /*db.Database.ExecuteSqlRaw(passwordSql, paswordhashSql, paswordsaltSql, SqlEmail);*/

                //old
                /*byte[] hash = Encoding.ASCII.GetBytes(paswordhashSql);*/

                /*byte[] salt = Encoding.ASCII.GetBytes(paswordsaltSql);*/

   /*             using (var hmac = new HMACSHA512(salt))
                {
                    var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordSql));
                    return computeHash.SequenceEqual(hash);
                }*/

            }
        }

    }
}
