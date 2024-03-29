﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBll = BLL.models.UserBll;
using UserDal = DAL.models.UserDal;

namespace BLL.mapper
{
    public static class UserMapperBll
    {

        public static UserBll ToBll(this UserDal userModelDal)
        {

            UserBll userBll = new UserBll(userModelDal.idUser, userModelDal.name , userModelDal.lastName , userModelDal.adress, userModelDal.city , userModelDal.email , userModelDal.password, userModelDal.passwordHash , userModelDal.passwordSalt ); 
            
            return userBll;
        }

        // Data from BLL To DAL converter

        public static UserDal ToDal(this UserBll userModelBll)
        {

            UserDal userDal = new UserDal(userModelBll.idUser, userModelBll.name, userModelBll.lastName, userModelBll.adress, userModelBll.city, userModelBll.email, userModelBll.password, userModelBll.passwordHash, userModelBll.passwordSalt);;

            return userDal;
        }

    }
}
