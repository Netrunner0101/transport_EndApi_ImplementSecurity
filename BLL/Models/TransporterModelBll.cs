using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TransporterModelBll
    {

        public TransporterModelBll(int id_transporter, string? name, string? adress, string? email, string?phoneNumber, ICollection<DriverModelBll>? drivers, ICollection<DeliveryModelBll>? deliveries)
        {
            this.id_transporter = id_transporter;
            this.name = name;
            this.adress = adress;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.drivers = drivers;
            this.deliveries = deliveries;
        }

        public int id_transporter { get; set; }

        public string? name { get; set; }

        public string? adress { get; set; }

        public string? email { get; set; }

        public string? phoneNumber { get; set; }

        // relation 1:n
        public ICollection<DriverModelBll>? drivers { get; set; }

        // relation n:n
        public ICollection<DeliveryModelBll>? deliveries { get; set; }

    }
}
