using TransporterApiModel = entity_jwt_aspnetcore.models.TransporterApiModel;
using TransporterModelBll = BLL.Models.TransporterModelBll;

namespace entity_jwt_aspnetcore.mapper
{
    public static class TransporterApiMapper
    {

        // Bll To Api

        public static TransporterApiModel ToApi(this TransporterModelBll transporterModelBll)
        {
            TransporterApiModel transporterApiModel = new TransporterApiModel(transporterModelBll.id_transporter, transporterModelBll.name, transporterModelBll.adress, transporterModelBll.email, transporterModelBll.phoneNumber, transporterModelBll.drivers?.Select(d=>d.ToApi()).ToList(), transporterModelBll.deliveries?.Select(d => d.ToApi()).ToList()) ;

            return transporterApiModel;
        }


        // Api To Bll


        public static TransporterModelBll ToBll(this TransporterApiModel transporterApiModel)
        {
            TransporterModelBll transporterModelBll = new TransporterModelBll(transporterApiModel.id_transporter, transporterApiModel.name, transporterApiModel.adress, transporterApiModel.email, transporterApiModel.phoneNumber, transporterApiModel.drivers?.Select(d=>d.ToBll()).ToList(), transporterApiModel.deliveries?.Select(d => d.ToBll()).ToList());

            return transporterModelBll;
        }


    }
}
