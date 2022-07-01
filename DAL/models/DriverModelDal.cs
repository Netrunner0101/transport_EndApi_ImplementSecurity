using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.models
{
    [Table("driver")]
    public class DriverModelDal
    {
        public DriverModelDal (int id_drive, string? name, string? email, string? phoneNumber, ICollection<TransporterModelDal>? transporters)
        {
            this.id_drive = id_drive;
            
            this.name = name;
            
            this.email = email;
            
            this.phoneNumber = phoneNumber;
            
            this.transporters = transporters;
        }
        public DriverModelDal()
        {

        }

        [Key]
        public int id_drive { get; set; }

        public string? name { get; set; }

        public string? email { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string? phoneNumber { get; set; }

        //relation n:n 
        public ICollection<TransporterModelDal>? transporters { get; set; }  

    }
}
