using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DriverModelBll
    {
        public DriverModelBll(int id_drive, string? name, string? email, string? phoneNumber, ICollection<TransporterModelBll>? transporters)
        {
            this.id_drive = id_drive;

            this.name = name;

            this.email = email;

            this.phoneNumber = phoneNumber;

            this.transporters = transporters;
        }

        public int id_drive { get; set; }

        public string? name { get; set; }

        public string? email { get; set; }

        public string? phoneNumber { get; set; }

        // relation n:n
        public ICollection<TransporterModelBll>? transporters { get; set; }

    }
}
