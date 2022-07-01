using BLL.mapper;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryServiceDal = DAL.services.DeliveryServiceDal;

namespace BLL.services
{
    public class DeliveryServiceBll
    {
        public readonly DeliveryServiceDal _deliveryService;

        public DeliveryServiceBll(DeliveryServiceDal deliveryService)
        {
            _deliveryService = deliveryService;
        }

        public void CreateNewDelivery(DeliveryModelBll delivery)
        {
            _deliveryService.Create(delivery.ToDal());
        }

        public void DeleteDelivery(int idtr)
        {
            _deliveryService.Delete(idtr);
        }

        public IEnumerable<DeliveryModelBll> GetAllDeliveries()
        {
            return _deliveryService.GetAll().Select(del=>del.ToBll());
        }

        public DeliveryModelBll GetDeliveryById(int idtr)
        {
            return _deliveryService.GetById(idtr).ToBll();
        }

        /// <summary>
        /// Get transporter 
        /// </summary>
        /// <param name="iddel"></param>
        /// <returns></returns>
        public DeliveryModelBll GetDeliveryTransporterById(int iddel) 
        {
            return _deliveryService.GetDeliveryTransporterId(iddel).ToBll();
        }


        public void UpdataDelivery(DeliveryModelBll delivery, int idtr)
        {
            _deliveryService.Update(delivery.ToDal(), idtr);
        }


        /// <summary>
        /// Update Delivery Transproter by adding new transporter into the relation
        /// </summary>
        /// <param name="delTransporter"></param>
        /// <param name="iddel"></param>
        
         public void UpdateDeliveryTransporter(TransporterModelBll delTransporter,int iddel)
        {
            _deliveryService.UpdateDeliveryTransproter(delTransporter.ToDal(), iddel);
        }

        /// <summary>
        /// Insert transporter id with an specific id
        /// </summary>
        /// <param name="iddel"></param>
        /// <param name="idtrans"></param>

        public void CreateDeliveryTransporter(int iddel, int idtrans)
        {
           _deliveryService.CreateDeliveryTransporter(iddel, idtrans);
        }

        /// <summary>
        /// Update transporter id with an specific id
        /// </summary>
        /// <param name="iddel"></param>
        /// <param name="idtrans"></param>

        public void UpdateDeliveryTransporter(int iddel, int idtrans)
        {
            _deliveryService.UpdateDeliveryTransporter(iddel, idtrans);
        }

        //UpdateDeliveryCustomers
        /*        public void UpdateDeliveryCustomers(CustomerModelBll delCustomer, int iddel)
                {
                    _deliveryService.UpdateDeliveryCustomers(delCustomer.ToDal(), iddel);
                }*/

        // Update remarks
        public void UpdateRemarksDelivery(string remarks,int iddel) 
        {
            _deliveryService.UpdateRemarks(remarks,iddel);
        }

    }
}
