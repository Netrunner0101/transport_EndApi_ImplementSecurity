namespace transport_csharp.modelsDto
{
    public class JwtSettings
    {
        public bool ValidateIssuerSignInKey { get; set; }

        public string IssuerSignInKey { get; set; }

        public bool ValidateIssuer { get; set; } 

        public string ValidIssuer { get; set; }

        public bool ValidateAudience { get; set; }  

        public string ValidAudience { get; set; }

        public bool RequireExpirationTime { get; set; }

        public bool ValidateLifeTime { get; set; } 
    }
}
