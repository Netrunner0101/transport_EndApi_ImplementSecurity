using BLL.services;
using entity_jwt_aspnetcore.mapper;
using entity_jwt_aspnetcore.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace entity_jwt_aspnetcore.Controllers
{
    [Route("tms")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        public readonly CustomerServiceBll _customerService;

        public CustomerController(CustomerServiceBll customerService)
        {
            _customerService = customerService;
        }

        [Route("customers")]
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            IEnumerable<CustomerApiModel> customers = _customerService.GetAllCustomer().Select(cus => cus.ToApi());
            return Ok(customers);
        }

        [Route("customer/{idc}")]
        [HttpGet]
        public IActionResult GetCustomerById(int idc)
        {
            CustomerApiModel customer = _customerService.GetByIdCustomer(idc).ToApi();
            return Ok(customer);
        }

        [Route("customer/name/{name}")]
        [HttpGet]
        public IActionResult GetCustomerByName(string name)
        {
            CustomerApiModel customer = _customerService.GetByCustomerName(name).ToApi();
            return Ok(customer);
        }

        [Route("customer/create")]
        [HttpPost]
        public IActionResult CreateNewCustomer([FromBody]CustomerApiModel customer)
        {   
            if(customer == null)
            {
                return BadRequest("No data in customer cannot create");
            }
            _customerService.CreateCustomer(customer.ToBll());
            return Ok(customer);
        }

        [Route("customer/update/{idc}")]
        [HttpPut]
        public IActionResult updateCustomer([FromBody] CustomerApiModel customer, int idc)
        {
            if (customer == null)
            {
                return BadRequest("No update possible .");
            }
            _customerService.UpdateCustomer(customer.ToBll(),idc);

            return Ok(customer);
        }

        /// <summary>
        /// Create the relation for join table
        /// </summary>
        /// <param name="idc"></param>
        /// <param name="iddel"></param>
        /// <returns></returns>
        [Route("customerCreate/{idc}/Delivery/{iddel}")]
        [HttpPost]
        public IActionResult CreateCustomerDeliveryById(int idc, int iddel)
        {
            if (idc == null || iddel == null)
            {
                return BadRequest("Error , create new relationship fail.");
            }
            _customerService.CreateCustomerDeliveryById(idc, iddel);

            return Ok("Success creating new relationship for customer_delivery");
        }

        /// <summary>
        /// Update an existing relationship 
        /// </summary>
        /// <param name="idc"></param>
        /// <param name="iddel"></param>
        /// <returns></returns>
        [Route("customerUpdate/{idc}/Delivery/{iddel}")]
        [HttpPut]
        public IActionResult updateCustomerDeliveryById(int idc, int iddel)
        {
            if (idc == null || iddel == null)
            {
                return BadRequest("Error , update fail.");
            }
            _customerService.UpdateCustomerDeliveryByExistingId(idc, iddel);

            return Ok("Success ");
        }

        /// <summary>
        /// Update the relation with existing join table
        /// </summary>
        /// <param name="cusDelivery"></param>
        /// <param name="idc"></param>
        /// <returns></returns>
/*        [Route("customer/update/Delivery/{idc}")]
        [HttpPut]
        public IActionResult updateCustomerDelivery([FromBody] DeliveryApiModel cusDelivery, int idc)
        {
            if (cusDelivery == null)
            {
                return BadRequest("Error , update fail.");
            }
            _customerService.UpdateCustomerDelivery(cusDelivery.ToBll(), idc);

            return Ok(cusDelivery);
        }*/

        [Route("customer/delete/{idc}")]
        [HttpDelete]
        public IActionResult DeleteCustomer(int idc)
        {
            _customerService.DeleteCustomer(idc);
            return Ok("Delete customer");
        }
    }
}
