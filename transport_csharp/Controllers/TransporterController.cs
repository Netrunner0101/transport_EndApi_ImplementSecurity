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
    public class TransporterController : ControllerBase
    {

        public readonly TransporterServiceBll _transporterService;

        public TransporterController(TransporterServiceBll transporterService)
        {
            _transporterService = transporterService;
        }

        [Route("transporters")]
        [HttpGet]
        public IActionResult GetAllTransporter()
        {
            IEnumerable<TransporterApiModel> transporters = _transporterService.GetAllTransporter().Select(trans => trans.ToApi());
            return Ok(transporters);
        }

        [Route("transporter/{idtrans}")]
        [HttpGet]
        public IActionResult GetTransporterById(int idtrans)
        {
            TransporterApiModel transporter = _transporterService.GetTransporterById(idtrans).ToApi();
            return Ok(transporter);
        }

        [Route("transporter/name/{name}")]
        [HttpGet]
        public IActionResult GetTransporterByName(string name)
        {
            TransporterApiModel transporter = _transporterService.GetTransporterByName(name).ToApi();
            return Ok(transporter);
        }

        [Route("transporter/create")]
        [HttpPost]
        public IActionResult CreateNewTransporter([FromBody] TransporterApiModel transporter)
        {
            if (transporter == null)
            {
                return BadRequest("No data in transporter cannot create");
            }

            _transporterService.CreateTransporter(transporter.ToBll());

            return Ok(transporter);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="transporter"></param>
        /// <param name="idtrans"></param>
        /// <returns></returns>
        [Route("transporter/update/{idtrans}")]
        [HttpPut]
        public IActionResult UpdateTransporter([FromBody] TransporterApiModel transporter, int idtrans)
        {
            if (transporter == null)
            {
                return BadRequest("No update possible for transporter .");
            }

            _transporterService.UpdateTransporter(transporter.ToBll(), idtrans);

            return Ok(transporter);
        }

        /// <summary>
        /// Add transporter model into join relationship
        /// </summary>
        /// <param name="transDriver"> Driver Models (Choose from layer + don't forget mapper) </param>
        /// <param name="idtrans"></param>
        /// <returns></returns>
        [Route("transporter/{idtrans}/update/driver")]
        [HttpPut]
        public IActionResult UpdateTransporterDrivers([FromBody] DriverApiModel transDriver, int idtrans)
        {
            if (transDriver == null)
            {
                return BadRequest("No update possible for transporter .");
            }

            _transporterService.UpdateTransporterDrivers(transDriver.ToBll(), idtrans);

            return Ok(transDriver);
        }

        /// <summary>
        /// Create new relation for transporter_driver join table
        /// </summary>
        /// <param name="idtrans"></param>
        /// <param name="iddrive"></param>
        /// <returns></returns>
        [Route("transporterCreate/{idtrans}/driver/{iddrive}")]
        [HttpPost]
        public IActionResult CreateTransporterDriversById(int idtrans, int iddrive)
        {
            if (idtrans == null || iddrive == null)
            {
                return BadRequest("Error not possible to create a new relation for transporter_driver join table.");
            }
            _transporterService.CreateTransporterDriversById(idtrans, iddrive);

            return Ok("Success creating new relation in the table transporter_driver");
        }

        /// <summary>
        /// Update new relation for transporter_driver join table
        /// </summary>
        /// <param name="idtrans"></param>
        /// <param name="iddrive"></param>
        /// <returns></returns>
        [Route("transporterUpdate/{idtrans}/driver/{iddrive}")]
        [HttpPut]
        public IActionResult UpdateTransporterDriversById(int idtrans, int iddrive)
        {
            if (idtrans == null || iddrive == null)
            {
                return BadRequest("Error not possible to update a new relation for transporter_driver join table.");
            }
            _transporterService.UpdateTransporterDriversById(idtrans, iddrive);

            return Ok("Success updating new relation in the table transporter_driver");
        }

        [Route("transporterDelete/{idtrans}")]
        [HttpDelete]
        public IActionResult DeleteTransporter(int idtrans)
        {
            _transporterService.DeleteTransporter(idtrans);

            return Ok("Sucess delete transporter");
        }

    }
}
