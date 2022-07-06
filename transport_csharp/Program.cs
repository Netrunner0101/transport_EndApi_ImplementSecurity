using BLL.services;
using DAL.services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Configuration;
using System.Text;
using transport_csharp.modelsDto;

var builder = WebApplication.CreateBuilder(args);

JwtSettings jwtSettings = new JwtSettings();

builder.Configuration.Bind("AppSettings:jwt", jwtSettings);

builder.Services.AddSingleton(jwtSettings);


// Add services to the container.

builder.Services.AddControllers();

// Authentication Bearer

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme"

        //Description = "Standard authorization scheme using the bearer scheme with bearer token",
        //In = ParameterLocation.Header,
        //Name = "Authorization",
        //Type = SecuritySchemeType.ApiKey
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


// Eric authentication 

/*builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Standard authorization scheme using the bearer scheme with bearer token",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
});

*/
/*options.OperationFilter<SecurityRequirementsOperationFilter>(); // Mat Frayer*/

//Add authentication middleware
/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;// si jamais mets ici false si ton https merde
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSignInKey,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.IssuerSignInKey)),
            ValidateIssuer = jwtSettings.ValidateIssuer,
            ValidIssuer = jwtSettings.ValidIssuer,
            ValidateAudience = jwtSettings.ValidateAudience,
            ValidAudience = jwtSettings.ValidAudience,
            RequireExpirationTime = jwtSettings.RequireExpirationTime,
            ValidateLifetime = jwtSettings.RequireExpirationTime,
            ClockSkew = TimeSpan.FromDays(1),
        };
    });
*/

//Add authentication middleware
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {   // is the appsettings: token in app.json file
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey
           (
               Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)
           ),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


/// <summary>
///  Version Alex
/// </summary>

/*builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;// si jamais mets ici false si ton https merde
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSignInKey,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.IssuerSignInKey)),
            ValidateIssuer = jwtSettings.ValidateIssuer,
            ValidIssuer = jwtSettings.ValidIssuer,
            ValidateAudience = jwtSettings.ValidateAudience,
            ValidAudience = jwtSettings.ValidAudience, 
            RequireExpirationTime = jwtSettings.RequireExpirationTime,  
            ValidateLifetime = jwtSettings.RequireExpirationTime,
            ClockSkew = TimeSpan.FromDays(1),
        };
    }
);*/



// If unable to read BllService is because of dependency injection problem.
// Il faut ajouter chaque repository 
// Must Add all service from dal

builder.Services.AddScoped<AuthServiceDal>((b) => new AuthServiceDal(builder.Configuration.GetConnectionString("Connection2")));

builder.Services.AddScoped<CustomerServiceDal>((b) => new CustomerServiceDal(builder.Configuration.GetConnectionString("Connection2")));

builder.Services.AddScoped<DeliveryServiceDal>((b) => new DeliveryServiceDal(builder.Configuration.GetConnectionString("Connection2")));

builder.Services.AddScoped<DriverServiceDal>((b) => new DriverServiceDal(builder.Configuration.GetConnectionString("Connection2")));

builder.Services.AddScoped<TransporterServiceDal>((b) => new TransporterServiceDal(builder.Configuration.GetConnectionString("Connection2")));

// Dont forget to inject all depency like BLL .


builder.Services.AddScoped<AuthServiceBll>();

builder.Services.AddScoped<CustomerServiceBll>();

builder.Services.AddScoped<DeliveryServiceBll>();

builder.Services.AddScoped<DriverServiceBll>();

builder.Services.AddScoped<TransporterServiceBll>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add Authentication()
app.UseAuthentication();

app.UseAuthorization();

app.UseCors("EnableCORS");

app.MapControllers();

app.Run();
