﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.models
{
    [Table("user")]
    public class UserDal
    {       
        public UserDal( int idUser, string? name , string? lastName ,string? adress , string? city, string? email ,string? password , byte[]? passwordHash ,byte[]? passwordSalt)
        {
            this.idUser = idUser;

            this.name = name;

            this.lastName = lastName;

            this.adress = adress;

            this.city = city;
            
            this.email = email;
            
            this.password = password;

            this.passwordHash = passwordHash;

            this.passwordSalt = passwordSalt;
        }

        public UserDal()
        {

        }

        // User model
        [Key]
        public int idUser { get; set; }

        public string? name { get; set; }

        public string? lastName { get; set; }

        public string? adress { get; set; }

        public string? city { get; set; }

        public string? email { get; set; } 

        public string? password { get; set; } 

        public byte[]? passwordHash { get; set; }

        public byte[]? passwordSalt { get; set; }

/*        // One To Many
        public ICollection<DeliveryModelDal>? deliveries { get; set; } */

    }
}
