using System.ComponentModel.DataAnnotations;

namespace transport_csharp.modelsDto
{
    public class UserLogin
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }    

    }
}
