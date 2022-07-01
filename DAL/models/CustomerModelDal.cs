using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.models
{
    [Table("customer")]
    public class CustomerModelDal
    {
        // Is a constructor
        /* For constructor , i need to have one with parameters that is for the mappers because many to many relationship 
         *  does work for migrations . => noe Enumarable
         *  
         *  And a second constructor for the working BUT not for mappers
         */

        public CustomerModelDal(int id_customer, string? name, string? vat, string? adress, string? email, string? phoneNumber, ICollection<DeliveryModelDal>? deliveries)
        {
            this.id_customer = id_customer;

            this.name = name;

            this.vat = vat;

            this.adress = adress;

            this.email = email;

            this.phoneNumber = phoneNumber;

            this.deliveries = deliveries;
        }

        public CustomerModelDal()
        {

        }

        [Key]
        public int id_customer { get; set; }

        public string? name { get; set; }

        public string? vat { get; set; }

        public string? adress { get; set; }

        public string? email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? phoneNumber { get; set; }

        // relation n:n
        public ICollection<DeliveryModelDal>? deliveries { get; set; }

    }
}
