using BLL.Models;
using DAL.models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerModelBll = BLL.Models.CustomerModelBll;
using CustomerModelDal = DAL.models.CustomerModelDal;

namespace BLL.mapper
{
    public static class CustomerMapperBll
    {
        // Example
        // Data from DAL To BLL converter

  
        public static CustomerModelBll ToBll (this CustomerModelDal customerModelDal)
        {

            CustomerModelBll customerModelBll = new CustomerModelBll(customerModelDal.id_customer, customerModelDal.name, customerModelDal.vat, customerModelDal.adress, customerModelDal.email, customerModelDal.phoneNumber, customerModelDal.deliveries?.Select(d => d.ToBll()).ToList() ) ;

            return customerModelBll;
        }

        // Data from BLL To DAL converter
    
        public static CustomerModelDal ToDal(this CustomerModelBll customerModelBll)
        {

            CustomerModelDal customerModelDal = new CustomerModelDal(customerModelBll.id_customer, customerModelBll.name, customerModelBll.vat, customerModelBll.adress, customerModelBll.email, customerModelBll.phoneNumber, customerModelBll.deliveries?.Select(d => d.ToDal()).ToList());

            return customerModelDal;
        }

    }
}
