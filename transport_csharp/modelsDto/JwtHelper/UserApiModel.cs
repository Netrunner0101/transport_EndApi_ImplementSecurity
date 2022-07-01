using entity_jwt_aspnetcore.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace entity_jwt_aspnetcore.models
{
    public class UserApiModel
    {

        public UserApiModel(int idUser, string? userName, string? password, string? email, byte[]? passwordHash, byte[]? passwordSalt)
        {
            this.idUser = idUser;

            this.userName = userName;

            this.password = password;

            this.email = email;

            this.passwordHash = passwordHash;

            this.passwordSalt = passwordSalt;

/*            this.deliveries = deliveries;*/
        }

        public UserApiModel()
        {
        }

        // User model
        public int idUser { get; set; }

        public string? userName { get; set; }

        public string? password { get; set; }

        public string? email { get; set; }

        public byte[]? passwordHash { get; set; }

        public byte[]? passwordSalt { get; set; }

        // One To Many
/*        [JsonIgnore]
        public ICollection<DeliveryApiModel>? deliveries { get; set; } */

    }
}
