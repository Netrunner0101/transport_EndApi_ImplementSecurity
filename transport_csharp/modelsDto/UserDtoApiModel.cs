using entity_jwt_aspnetcore.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace entity_jwt_aspnetcore.models
{
    public class UserDtoApiModel
    {

        public UserDtoApiModel(int idUserDto, string? userName, string? password)
        {
            this.idUserDto = idUserDto;

            this.userName = userName;

            this.password = password;

/*            this.deliveries = deliveries;*/
        }


        public UserDtoApiModel()
        {
        }

        public int idUserDto { get; set; }

        public string? userName { get; set; } 

        public string? password { get; set; } 
        
  /*      [JsonIgnore]
        public ICollection<DeliveryApiModel>? deliveries { get; set; }*/
    }
}
