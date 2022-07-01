using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.models
{
    [Table("user")]
    public class UserDal
    {       
        public UserDal( int idUser,string? userName , string? password, string? email , byte[]? passwordHash ,byte[]? passwordSalt)
        {
            this.idUser = idUser;

            this.userName = userName;

            this.password = password;

            this.email = email;

            this.passwordHash = passwordHash;

            this.passwordSalt = passwordSalt;
        }

        public UserDal()
        {

        }

        // User model
        [Key]
        public int idUser { get; set; }

        public string? userName { get; set; } 

        public string? email { get; set; } 

        public string? password { get; set; } 

        public byte[]? passwordHash { get; set; }

        public byte[]? passwordSalt { get; set; }

/*        // One To Many
        public ICollection<DeliveryModelDal>? deliveries { get; set; } */

    }
}
