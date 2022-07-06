using BLL.mapper;
using BLL.models;
using DAL.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.services
{
    public class AuthServiceBll
    {

        public readonly AuthServiceDal _authService;

        public AuthServiceBll (AuthServiceDal authServiceDal)
        {
            _authService = authServiceDal;
        }

        public void CreateUser(UserBll newUser)
        {
            _authService.Create(newUser.ToDal());
        }

        public UserBll GetUserDetailsByEmail(string email)
        {
            return _authService.GetDetailsByEmail(email).ToBll();
        }

        public void DeleteUser(string email)
        {
            _authService.Delete(email);
        }

        public IEnumerable<UserBll> GetAllUser()
        {
          return _authService.GetAll().Select(users => users.ToBll()).ToList();
        }

        public UserBll GetUser(string email)
        {
            return _authService.GetByEmail(email).ToBll();
        }

        // Check Email
        public bool AccountEmailChecking(string email)
        {
            return _authService.checkEmail(email);
        }

        // Check Password
        public bool AccountPasswordChecking(string email, string password, byte[] passwordHash, byte[] passwordSalt)
        {
            return _authService.checkPassword(email, password, passwordHash, passwordSalt);
        }

        // Create password


        /*
                public UserBll checkIfEmailUserExist(string email)
                {
                    if (email != null)
                    {
                        UserBll userExist = _authService.checkEmail(email).ToBll();
                        if (userExist != null)
                        {
                            return userExist;
                        }   
                    }
                    throw new Exception("User Does'nt exist");
                }*/


        /*
                private string CreateTokenService(UserBll user)
                {
                   _authService.
                }

                private void CreatePasswordHashService(string password, out byte[] passwordHash, out byte[] passwordSalt)
                {

                }

                private bool VerifyPassordHashService(string password, byte[] passwordHash, byte[] passwordSalt)
                {

                }*/

    }
}
