using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CustomerModelBll
    {   
        // Is a Constructor
        public CustomerModelBll(int id_customer, string? name, string? vat, string? adress, string? email,string? phoneNumber, ICollection<DeliveryModelBll>? deliveries)
        {
            this.id_customer = id_customer;

            this.name= name;

            this.vat = vat;

            this.adress= adress;

            this.email = email;

            this.phoneNumber= phoneNumber;

            this.deliveries = deliveries;
        }


        public int id_customer { get; set; }

        public string? name { get; set; }

        public string? vat { get; set; }

        public string? adress { get; set; }

        public string? email { get; set; }

        public string? phoneNumber { get; set; }

        // relation n:n
        public ICollection<DeliveryModelBll>? deliveries { get; set; }
    }

    
}
