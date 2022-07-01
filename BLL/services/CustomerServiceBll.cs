using BLL.mapper;
using BLL.Models;
using DAL.models;
using CustomerServiceDal = DAL.services.CustomerServiceDal;

namespace BLL.services
{
    public class CustomerServiceBll
    {
        public readonly CustomerServiceDal _customerService;

        public CustomerServiceBll(CustomerServiceDal customerSericeDal)
        {
            _customerService = customerSericeDal;
        }

        // Envoye objet BLL qui sera convertir en DAL 
        public void CreateCustomer(CustomerModelBll customer)
        {
            _customerService.Create(customer.ToDal());  
        }

        public void DeleteCustomer(int idc)
        {
            _customerService.Delete(idc);
        }

        // Get all customer

        public IEnumerable<CustomerModelBll> GetAllCustomer()
        {
            return _customerService.GetAll().Select(cus=>cus.ToBll()) ;
        }

        // Return by id
        public CustomerModelBll GetByIdCustomer(int idc)
        {
            return _customerService.GetById(idc).ToBll();
        }

        public void UpdateCustomer(CustomerModelBll customer, int idc)
        {
            _customerService.Update(customer.ToDal(),idc);
        }

        // Update the relation

        public void UpdateCustomerDelivery(DeliveryModelBll custDelivery, int idc)
        {
            _customerService.UpdateCustomerDeliveries(custDelivery.ToDal(), idc);
        }

        // Create the relation for join table

        public void CreateCustomerDeliveryById(int idc, int iddel) 
        {
            _customerService.CreateCustomerDeliveryById(idc, iddel);
        }

        // Update the relation with existing join table

        public void UpdateCustomerDeliveryByExistingId(int idc, int iddel)
        {
            _customerService.UpdateCustomerExistingDeliveryById(idc, iddel);
        }


    }
}
