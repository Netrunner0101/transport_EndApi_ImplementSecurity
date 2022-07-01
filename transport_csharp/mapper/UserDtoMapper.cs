using BLL.models;
using  entity_jwt_aspnetcore.models;
// Use alias only if namespace are the same but in different layer


namespace transport_csharp.mapper
{
    public static class UserDtoMapper
    {

        public static UserDtoBll ToBll(this UserDtoApiModel userApiModel)
        {

            UserDtoBll userDtoBll = new UserDtoBll(userApiModel.idUserDto, userApiModel.userName, userApiModel.password);

            return userDtoBll;
        }


        public static UserDtoApiModel ToApi(this UserDtoBll userBll)
        {

            UserDtoApiModel userDtoApiModel = new UserDtoApiModel(userBll.idUserDto, userBll.userName, userBll.password);

            return userDtoApiModel;
        }

    }
}
