using BLL.Models;
using CustomerModelBll = BLL.Models.CustomerModelBll;
using CustomerApiModel = entity_jwt_aspnetcore.models.CustomerApiModel;

namespace entity_jwt_aspnetcore.mapper

{
    public static class CustomerApiMapper
    {

        /* Two ways to return constructor :
         * 
         *  1) Ininitalise model  ( ex : return model; )
         *  
         *  2) return a new model ( ex : return new model{} )
         */

        // Data from BLL To API converter

        public static CustomerModelBll ToBll(this CustomerApiModel customerApiModel)
        {
            CustomerModelBll customerBll = new CustomerModelBll(customerApiModel.id_customer, customerApiModel.name, customerApiModel.vat,customerApiModel.adress,customerApiModel.email, customerApiModel.phoneNumber, customerApiModel.deliveries?.Select(d => d.ToBll() ).ToList() );

            return customerBll;
        }

        // Data from API To BLL converter

        public static CustomerApiModel ToApi(this CustomerModelBll customerBll)
        {
            CustomerApiModel customerApi = new CustomerApiModel(customerBll.id_customer, customerBll.name, customerBll.vat, customerBll.adress, customerBll.email, customerBll.phoneNumber, customerBll.deliveries?.Select(d => d.ToApi()).ToList());

            return customerApi;

        }


    }
}
