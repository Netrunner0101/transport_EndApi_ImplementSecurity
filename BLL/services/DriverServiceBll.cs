using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.mapper;
using BLL.Models;
using DAL.services;

namespace BLL.services
{
    public class DriverServiceBll
    {

        public readonly DriverServiceDal _driverService;

        public DriverServiceBll(DriverServiceDal driverService)
        {
            _driverService = driverService;
        }

        public void CreateNewDriver(DriverModelBll driver)
        {
            _driverService.Create(driver.ToDal());
        }

        public void DeleteDriver(int iddriver)
        {
            _driverService.Delete(iddriver);
        }

        public IEnumerable<DriverModelBll> GetAllDrivers()
        {
            return _driverService.GetAll().Select(drivers => drivers.ToBll());
        }

        public DriverModelBll GetDriverById(int iddriver)
        {
            return _driverService.GetById(iddriver).ToBll();
        }

        public DriverModelBll GetDriverByName(string name)
        {
            return _driverService.GetByName(name).ToBll();
        }

        public void UpdateDriver(DriverModelBll driver,int iddriver)
        {
            _driverService.Update(driver.ToDal(), iddriver);
        }

    }
}
