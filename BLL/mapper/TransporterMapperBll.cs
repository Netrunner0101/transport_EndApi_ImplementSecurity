using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporterModelDal = DAL.models.TransporterModelDal;
using TransporterModelBll = BLL.Models.TransporterModelBll;
using DAL.models;

namespace BLL.mapper
{
    public static class TransporterMapperBll
    {

        // DAL to BLL
        public static TransporterModelBll ToBll (this TransporterModelDal transporterModelDal)
        {

            TransporterModelBll transporterModelBll = new TransporterModelBll(transporterModelDal.id_transporter, transporterModelDal.name, transporterModelDal.adress, transporterModelDal.email, transporterModelDal.phoneNumber, transporterModelDal.drivers?.Select(t => t.ToBll()).ToList() , transporterModelDal.deliveries?.Select(t => t.ToBll()).ToList());

            return transporterModelBll;

        }


        // BLL to DAL 
        public static TransporterModelDal ToDal(this TransporterModelBll transporterModelBll)
        {
            TransporterModelDal transporterModelDal = new TransporterModelDal(transporterModelBll.id_transporter, transporterModelBll.name, transporterModelBll.adress, transporterModelBll.email, transporterModelBll.phoneNumber, transporterModelBll.drivers?.Select(t => t.ToDal()).ToList(), transporterModelBll.deliveries?.Select(d => d.ToDal()).ToList() );

            return transporterModelDal;
        }
    }
}
