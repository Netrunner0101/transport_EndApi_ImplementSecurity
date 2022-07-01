using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.models
{
    public class UserDtoDal
    {

        public UserDtoDal(int idUserDto, string? userName, string? password)
        {
            this.idUserDto = idUserDto;

            this.userName = userName;

            this.password = password;
        }


        // UserDto is for request
        [Key]
        public int idUserDto { get; set; }

        public string? userName { get; set; }

        public string? password { get; set; }

        // One To Many
/*        public ICollection<DeliveryModelDal>? deliveries { get; set;}*/
    }
}
