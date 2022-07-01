using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryModelDal = DAL.models.DeliveryModelDal;
using DeliveryModelBll = BLL.Models.DeliveryModelBll;
using DAL.models;
using BLL.Models;

namespace BLL.mapper
{
    public static class DeliveryMapperBll
    {

        // Dal to Bll

        // Conversion ICollection
        public static DeliveryModelBll ToBll (this DeliveryModelDal deliveryModelDal)
        {

            DeliveryModelBll deliveryModelBll = new DeliveryModelBll(deliveryModelDal.id_delivery, deliveryModelDal.numeroDelivery, deliveryModelDal.weight,deliveryModelDal.adress,deliveryModelDal.dateDelivery,deliveryModelDal.dateTransfert,deliveryModelDal.remarks, (deliveryModelDal.transporters?.Select(t=>t.ToBll()).ToList()), (deliveryModelDal.customers?.Select(d => d.ToBll()).ToList() ));

            return deliveryModelBll;

        }

        // Bll to Dal

        // Conversion IEnumerable
        public static DeliveryModelDal ToDal ( this DeliveryModelBll deliveryModelBll)
        {

            DeliveryModelDal deliveryModelDal = new DeliveryModelDal(deliveryModelBll.id_delivery, deliveryModelBll.numeroDelivery, deliveryModelBll.weight, deliveryModelBll.adress, deliveryModelBll.dateDelivery, deliveryModelBll.dateTransfert, deliveryModelBll.remarks, deliveryModelBll.transporters?.Select(t => t.ToDal()).ToList(), deliveryModelBll.customers?.Select(c => c.ToDal()).ToList());

            return deliveryModelDal;
        }

    }
}
