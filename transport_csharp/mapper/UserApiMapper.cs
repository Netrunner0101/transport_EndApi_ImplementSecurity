using UserBll = BLL.models.UserBll;
using UserApiModel = entity_jwt_aspnetcore.models.UserApiModel;


namespace transport_csharp.mapper
{
    public static class UserApiMapper
    {

        public static UserBll ToBll(this UserApiModel userApiModel)
        {
            UserBll userBll = new UserBll(userApiModel.idUser, userApiModel.userName, userApiModel.password, userApiModel.email, userApiModel.passwordHash, userApiModel.passwordSalt );

            return userBll;
        }


        public static UserApiModel ToApi(this UserBll userBll)
        {

            UserApiModel userApiModel = new UserApiModel(userBll.idUser, userBll.userName, userBll.password, userBll.email, userBll.passwordHash, userBll.passwordSalt);

            return userApiModel;
        }

    }
}
