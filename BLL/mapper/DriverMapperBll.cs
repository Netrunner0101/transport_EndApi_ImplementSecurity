using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriverModelDal = DAL.models.DriverModelDal;
using DriverModelBll = BLL.Models.DriverModelBll;

namespace BLL.mapper
{
    public static class DriverMapperBll
    {

        // Dal To BLL

        public static DriverModelBll ToBll ( this DriverModelDal driverModelDal)
        {
            DriverModelBll driverModelBll = new DriverModelBll(driverModelDal.id_drive, driverModelDal.name, driverModelDal.email, driverModelDal.phoneNumber, driverModelDal.transporters?.Select(d=>d.ToBll()).ToList());

            return driverModelBll;
        }

        // Bll To Dal

        public static DriverModelDal ToDal ( this DriverModelBll driverModelBll)
        {
            DriverModelDal driverModelDal = new DriverModelDal(driverModelBll.id_drive, driverModelBll.name, driverModelBll.email, driverModelBll.phoneNumber, driverModelBll.transporters?.Select(d=>d.ToDal()).ToList());

            return driverModelDal;
        }

    }
}
