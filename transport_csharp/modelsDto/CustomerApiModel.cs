using System.Text.Json.Serialization;

namespace entity_jwt_aspnetcore.models
{   

    // If many relationships don't forget json ignore unless you will get de seriazable/deseriazable ERROR.

    public class CustomerApiModel
    {   
        // Always have 2 construtor : one for migration and one for environnement
        public CustomerApiModel(int id_customer, string? name, string? vat, string? adress, string? email, string? phoneNumber, ICollection<DeliveryApiModel>? deliveries)
        {
            this.id_customer = id_customer;

            this.name = name;
            
            this.vat = vat; 

            this.adress = adress;
            
            this.email = email;
            
            this.phoneNumber = phoneNumber;
            
            this.deliveries = deliveries;
        }

        public CustomerApiModel()
        {

        }

        public int id_customer { get; set; }

        public string? name { get; set; }

        public string? vat { get; set; }

        public string? adress { get; set; }

        public string? email { get; set; }

        public string? phoneNumber { get; set; }


        //Many to Many
        [JsonIgnore]
        public ICollection<DeliveryApiModel>? deliveries { get; set; }

    }
}
