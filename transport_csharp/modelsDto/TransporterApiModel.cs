using System.Text.Json.Serialization;

namespace entity_jwt_aspnetcore.models
{
    public class TransporterApiModel
    {

        public TransporterApiModel(int id_transporter, string? name, string? adress, string? email, string? phoneNumber, ICollection<DriverApiModel>? drivers, ICollection<DeliveryApiModel>? deliveries)
        {
            this.id_transporter = id_transporter;
            this.name = name;
            this.adress = adress;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.drivers = drivers; 
            this.deliveries = deliveries;
        }

        public TransporterApiModel()
        {

        }

        public int id_transporter { get; set; }

        public string? name { get; set; }

        public string? adress { get; set; }

        public string? email { get; set; }

        public string? phoneNumber { get; set; }

        // relation 1:n
        [JsonIgnore]
        public ICollection<DriverApiModel>? drivers { get; set; }

        // relation n:n[JsonIgnore]
        [JsonIgnore]
        public ICollection<DeliveryApiModel>? deliveries { get; set; }


    }
}
