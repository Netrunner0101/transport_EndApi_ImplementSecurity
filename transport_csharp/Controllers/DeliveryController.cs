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
    public class DeliveryController : ControllerBase
    {

        public readonly DeliveryServiceBll _deliveryService;

        public DeliveryController(DeliveryServiceBll customerService)
        {
            _deliveryService = customerService;
        }

        [Route("deliveries")]
        [HttpGet]
        public IActionResult GetAllDelievies()
        {
            IEnumerable<DeliveryApiModel> deliveries = _deliveryService.GetAllDeliveries().Select(dels => dels.ToApi());
            return Ok(deliveries);
        }

        [Route("delivery/{iddel}")]
        [HttpGet]
        public IActionResult GetDeliveryById(int iddel)
        {
            DeliveryApiModel delivery = _deliveryService.GetDeliveryById(iddel).ToApi();
            return Ok(delivery);
        }

        /// <summary>
        /// Get Specific transporter by Id
        /// </summary>
        /// <param name="iddel"></param>
        /// <returns></returns>
        /// 

        [Route("delivery/transporter/{iddel}")]
        [HttpGet]
        public IActionResult GetDeliveryTransporterById(int iddel)
        {
            DeliveryApiModel transporter = _deliveryService.GetDeliveryTransporterById(iddel).ToApi();
            return Ok(transporter);
        }


        [Route("delivery/create")]
        [HttpPost]
        public IActionResult CreateNewDelivery([FromBody] DeliveryApiModel delivery)
        {
            if (delivery == null)
            {
                return BadRequest("No data in delivery cannot create");
            }
 
            _deliveryService.CreateNewDelivery(delivery.ToBll());

            return Ok(delivery);
        }

        /// <summary>
        /// Update Remarks
        /// </summary>
        /// <param name="remarks"></param>
        /// <param name="iddel"></param>
        /// <returns></returns>
        
        [Route("delivery/update/{iddel}/remarks")]
        [HttpPut]
        public IActionResult UpdateRemarkDelivery(string remarks, int iddel)
        {
            if(remarks == null || iddel == null)
            {
                return BadRequest("You didn't enter a remarks.");
            }
            _deliveryService.UpdateRemarksDelivery(remarks, iddel);

            return Ok(remarks);
        }

    
        [Route("delivery/update/{iddel}")]
        [HttpPut]
        public IActionResult UpdateDelivery([FromBody] DeliveryApiModel delivery, int iddel)
        {
            if (delivery == null)
            {
                return BadRequest("No update possible .");
            }

            _deliveryService.UpdataDelivery(delivery.ToBll(), iddel);

            return Ok(delivery);
        }


        /// <summary>
        /// Update delivery , transporter with existing relationship
        /// </summary>
        /// <param name="transporter"></param>
        /// <param name="iddel"></param>
        /// <returns> Ok(success message)</returns>
        /// 
        [Route("delivery/{iddel}/addTransporter")]
        [HttpPut]
        public IActionResult UdpateDeliveryTransporter([FromBody] TransporterApiModel transporter, int iddel)
        {
            if (transporter == null)
            {
                return BadRequest("No update possible .");
            }

            _deliveryService.UpdateDeliveryTransporter(transporter.ToBll(), iddel);

            return Ok(transporter);
        }

        /// <summary>
        /// Update delivery by adding new transporter
        /// </summary>
        /// <param name="transporter"></param>
        /// <param name="iddel"></param>
        /// <returns></returns>

        [Route("deliveryUpdate/{iddel}/transporter/{idtrans}")]
        [HttpPut]
        public IActionResult UpdateDeliveryTransporter(int iddel, int idtrans)
        {
            if (iddel != null && idtrans != idtrans)
            {
                return BadRequest("No update possible .");
            }

            _deliveryService.UpdateDeliveryTransporter(iddel, idtrans);

            return Ok("Success updating relationship for delivery_transporter");
        }

        /// <summary>
        /// Insert transporter id with an specific id
        /// </summary>
        /// <param name="iddel"></param>
        /// <returns></returns>

        [Route("deliveryCreate/{iddel}/transporter/{idtrans}")]
        [HttpPost]
        public IActionResult CreateDeliveryTransporter(int iddel, int idtrans)
        {
            if (iddel != null && idtrans != idtrans)
            {
                return BadRequest("Error, cannot create the relation.");
            }

            _deliveryService.CreateDeliveryTransporter(iddel,idtrans);

            return Ok("Success creating new relationship for delivery_transporter");
        }

        /// <summary>
        /// Delete a delivery
        /// </summary>
        /// <param name="iddel"></param>
        /// <returns></returns>

        [Route("delivery/delete/{iddel}")]
        [HttpDelete]
        public IActionResult DeleteDelivery(int iddel)
        {

            _deliveryService.DeleteDelivery(iddel);

            return Ok("Sucess delete delivery");
        }



    }
}
