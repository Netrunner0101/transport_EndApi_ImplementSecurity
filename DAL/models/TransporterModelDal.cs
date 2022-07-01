using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.models
{
    [Table("transporter")]
    public class TransporterModelDal
    {   
        // Constructor

        // For the Mapper
        public TransporterModelDal(int id_transporter, string? name, string? adress, string? email, string? phoneNumber, ICollection<DriverModelDal>? drivers, ICollection<DeliveryModelDal>? deliveries)
        {
            this.id_transporter = id_transporter;
            
            this.name = name;
            
            this.adress = adress;
            
            this.email = email;
            
            this.phoneNumber = phoneNumber;
            
            this.drivers = drivers;
            
            this.deliveries = deliveries;   
        }

        public TransporterModelDal()
        {

        }

        [Key]
        public int id_transporter { get; set; }

        public string? name { get; set; }

        public string? adress { get; set; }

        public string? email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? phoneNumber { get; set; }

        // relation 1:n
        public ICollection<DriverModelDal>? drivers { get; set; }

        // relation n:n
        public ICollection<DeliveryModelDal>? deliveries { get; set; }

    }
}
