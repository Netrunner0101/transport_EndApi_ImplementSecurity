using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DeliveryModelBll
    {
    

        public DeliveryModelBll(int id_delivery, string? numeroDelivery, int? weight, string? adress, DateTime? dateTransfert, DateTime? dateDelivery, string? remarks, ICollection<TransporterModelBll>? transporters, ICollection<CustomerModelBll>? customers)
        {
            this.id_delivery = id_delivery;

            this.numeroDelivery = numeroDelivery;

            this.weight = weight;

            this.adress = adress;

            this.dateTransfert = dateTransfert;

            this.dateDelivery = dateDelivery;

            this.remarks = remarks;

            this.transporters = transporters;

            this.customers = customers;
        }

        public int id_delivery { get; set; }

        public string? numeroDelivery { get; set; }

        public int? weight { get; set; }

        public string? adress { get; set; }

        public DateTime? dateTransfert { get; set; }

        public DateTime? dateDelivery { get; set; }

        public string? remarks { get; set; }

        public ICollection<TransporterModelBll>? transporters { get; set; }

        public ICollection<CustomerModelBll>? customers { get; set; }
    }
}
