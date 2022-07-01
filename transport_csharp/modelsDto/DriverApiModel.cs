using System.Text.Json.Serialization;

namespace entity_jwt_aspnetcore.models
{
    public class DriverApiModel
    {
        public DriverApiModel(int id_drive, string? name, string? email, string? phoneNumber, ICollection<TransporterApiModel>? transporters)
        {
            this.id_drive = id_drive;

            this.name = name;
            
            this.email = email;
            
            this.phoneNumber = phoneNumber;
            
            this.transporters = transporters;
        }

        public DriverApiModel()
        {
        }


        public int id_drive { get; set; }

        public string? name { get; set; }

        public string? email { get; set; }

        public string? phoneNumber { get; set; }

        [JsonIgnore]
        public ICollection<TransporterApiModel>? transporters { get; set; }

    }
}
