using BLL.Models;
using DeliveryApiModel = entity_jwt_aspnetcore.models.DeliveryApiModel;
using DeliveryModelBll = BLL.Models.DeliveryModelBll ;

namespace entity_jwt_aspnetcore.mapper
{
    public static class DeliveryApiMapper
    {

        // Bll To Api

        public static DeliveryApiModel ToApi (this DeliveryModelBll deliveryModelBll)
        {
            DeliveryApiModel deliveryApiModel = new DeliveryApiModel(deliveryModelBll.id_delivery, deliveryModelBll.numeroDelivery, deliveryModelBll.weight, deliveryModelBll.adress, deliveryModelBll.dateDelivery, deliveryModelBll.dateTransfert, deliveryModelBll.remarks, deliveryModelBll.transporters?.Select(t =>t.ToApi()).ToList() , deliveryModelBll.customers?.Select(c => c.ToApi()).ToList() );
        
            return deliveryApiModel;
        }


        // Api To Bll


        public static DeliveryModelBll ToBll(this DeliveryApiModel deliveryApiModel)
        {
            DeliveryModelBll deliverModelBll = new DeliveryModelBll(deliveryApiModel.id_delivery, deliveryApiModel.numeroDelivery, deliveryApiModel.weight, deliveryApiModel.adress, deliveryApiModel.dateDelivery, deliveryApiModel.dateTransfert, deliveryApiModel.remarks, deliveryApiModel.transporters?.Select(t=>t.ToBll()).ToList() , (deliveryApiModel.customers?.Select(c=>c.ToBll()).ToList())) ;

            return deliverModelBll;
        }

    }
}
