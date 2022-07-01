using BLL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.models
{
    public class UserDtoBll
    {

        public UserDtoBll(int idUserDto, string? userName ,string? password )
        {
            this.idUserDto = idUserDto;

            this.userName = userName;

            this.password = password;  

            // Add terniary operator because i call a null and if try to add new list risk of error
/*
            this.deliveries = deliveries ?? new List<DeliveryModelBll>() ;*/
        }

        // UserDto is for request
        public int idUserDto { get; set; }

        public string? userName { get; set; }

        public string? password { get; set; } 

        // One To Many
 /*       public ICollection<DeliveryModelBll> deliveries { get; set;}*/
    }
}
