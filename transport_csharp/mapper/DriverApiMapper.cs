using DriverModelBll = BLL.Models.DriverModelBll;
using DriverApiModel = entity_jwt_aspnetcore.models.DriverApiModel;

namespace entity_jwt_aspnetcore.mapper
{
    public static class DriverApiMapper
    {

        // Bll To Api

        public static DriverApiModel ToApi(this DriverModelBll driverModelBll)
        {
            DriverApiModel driverApiModel = new DriverApiModel(driverModelBll.id_drive, driverModelBll.name, driverModelBll.email, driverModelBll.phoneNumber, driverModelBll.transporters?.Select(d=>d.ToApi()).ToList());

            return driverApiModel;
        }


        // Api To Bll


        public static DriverModelBll ToBll(this DriverApiModel driverApiModel)
        {
            DriverModelBll driverModelBll = new DriverModelBll(driverApiModel.id_drive, driverApiModel.name, driverApiModel.email, driverApiModel.phoneNumber, driverApiModel.transporters?.Select(d => d.ToBll()).ToList());

            return driverModelBll;
        }

    }
}
