namespace transport_csharp.modelsDto
{
    public class UserToken
    {  
/*        public int id { get; set; } */
        public string token { get; set; }

        public string email { get; set; }

        public bool isAdmin{ get; set; }

        public string userName { get; set; }

        public string password { get; set; }
    }
}
