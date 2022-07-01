using System.Text.Json.Serialization;

namespace entity_jwt_aspnetcore.models
{
    public class DeliveryApiModel
    {

        public DeliveryApiModel(int id_delivery, string? numeroDelivery, int? weight, string? adress, DateTime? dateTransfert, DateTime? dateDelivery, string? remarks, ICollection<TransporterApiModel>? transporters, ICollection<CustomerApiModel>? customers)
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

        public DeliveryApiModel()
        {

        }

        public int id_delivery { get; set; }

        public string? numeroDelivery { get; set; }

        public int? weight { get; set; }

        public string? adress { get; set; }

        public DateTime? dateTransfert { get; set; }

        public DateTime? dateDelivery { get; set; }

        public string? remarks { get; set; }


        // relation n:n
        [JsonIgnore]
        public ICollection<TransporterApiModel>? transporters { get; set; }

        // relation n:n
        [JsonIgnore]
        public ICollection<CustomerApiModel>? customers { get; set; }


    }
}
