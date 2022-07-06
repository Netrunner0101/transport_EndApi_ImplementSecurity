using DAL.services;
using DAL.models;
using BLL.mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.services
{
    public class TransporterServiceBll
    {

        public readonly TransporterServiceDal _transporterServiceDal;

        public TransporterServiceBll(TransporterServiceDal transporterServiceDal)
        {
            _transporterServiceDal = transporterServiceDal;
        }

        public void CreateTransporter(TransporterModelBll transporter)
        {
            _transporterServiceDal.Create(transporter.ToDal());
        }

        public void DeleteTransporter(int idtr)
        {
            _transporterServiceDal.Delete(idtr);
        }

        public IEnumerable<TransporterModelBll> GetAllTransporter()
        {
            return _transporterServiceDal.GetAll().Select(trans => trans.ToBll());
        }

        public TransporterModelBll GetTransporterById(int idtr)
        {
            return _transporterServiceDal.GetById(idtr).ToBll();
        }

        public TransporterModelBll GetTransporterByName(string name)
        {
            return _transporterServiceDal.GetByName(name).ToBll();
        }

        public void UpdateTransporter(TransporterModelBll transporter, int idtr)
        {
            _transporterServiceDal.Update(transporter.ToDal(), idtr);
        }

        // Add driver model into join_table transporter_drivers

        public void UpdateTransporterDrivers(DriverModelBll transportDriver, int idtrans)
        {
            _transporterServiceDal.UpdateTransporterDrivers(transportDriver.ToDal(), idtrans);
        }

        // Create driver and transporter relationship by Id
        public void CreateTransporterDriversById(int idtrans, int iddrive)
        {
            _transporterServiceDal.CreateTransporterDriversById(idtrans, iddrive);
        }

        // Update existing relationship for transporter_driver 
        public void UpdateTransporterDriversById(int idtrans, int iddrive)
        {
            _transporterServiceDal.UpdateTransporterDriversById(idtrans, iddrive);
        }


    }
}
