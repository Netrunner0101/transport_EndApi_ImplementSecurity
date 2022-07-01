using BLL.services;
using entity_jwt_aspnetcore.mapper;
using entity_jwt_aspnetcore.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace entity_jwt_aspnetcore.Controllers
{
    [Route("tms")]
    [ApiController]
    public class DriverController : ControllerBase
    {

        public readonly DriverServiceBll _driverService;

        public DriverController(DriverServiceBll driverService)
        {
            _driverService = driverService;
        }

        [Route("drivers")]
        [HttpGet]
        public IActionResult GetAllDrivers()
        {
            IEnumerable<DriverApiModel> drivers = _driverService.GetAllDrivers().Select(driver => driver.ToApi());
            return Ok(drivers);
        }

        [Route("driver/{iddriver}")]
        [HttpGet]
        public IActionResult GetDriverById(int iddriver)
        {
            DriverApiModel driver = _driverService.GetDriverById(iddriver).ToApi();
            return Ok(driver);
        }

        [Route("driver/create")]
        [HttpPost]
        public IActionResult CreateNewDriver([FromBody] DriverApiModel driver)
        {
            if (driver == null)
            {
                return BadRequest("No data in driver cannot create");
            }

            _driverService.CreateNewDriver(driver.ToBll());

            return Ok(driver);
        }


        [Route("driver/update/{iddriver}")]
        [HttpPut]
        public IActionResult CreateNewDriver([FromBody] DriverApiModel driver, int iddriver)
        {
            if (driver == null)
            {
                return BadRequest("No update possible for driver .");
            }

            _driverService.UpdateDriver(driver.ToBll(),iddriver);

            return Ok(driver);
        }


        [Route("driver/delete/{iddriver}")]
        [HttpDelete]
        public IActionResult DeleteDriver(int iddriver)
        {
            _driverService.DeleteDriver(iddriver);

            return Ok("Sucess delete Transporter");
        }

    }
}
