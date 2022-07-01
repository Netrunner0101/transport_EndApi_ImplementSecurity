using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDtoBll = BLL.models.UserDtoBll;
using UserDtoDal = DAL.models.UserDtoDal;

namespace BLL.mapper
{
    public static class UserDtoMapperBll
    {

        public static UserDtoBll ToBll(this UserDtoDal userDtoModelDal)
        {
            UserDtoBll userDtoBll = new UserDtoBll(userDtoModelDal.idUserDto, userDtoModelDal.userName, userDtoModelDal.password );

            return userDtoBll;
        }

        // Data from BLL To DAL converter

        public static UserDtoDal ToDal(this UserDtoBll userModelBll)
        {
            UserDtoDal userDtoDal = new UserDtoDal(userModelBll.idUserDto, userModelBll.userName, userModelBll.password);

            return userDtoDal;
        }

    }
}
