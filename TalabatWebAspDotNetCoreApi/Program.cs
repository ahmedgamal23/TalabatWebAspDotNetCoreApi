
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TalabatWebAspDotNetCoreApi.Data;
using TalabatWebAspDotNetCoreApi.Data.Model;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;
using TalabatWebAspDotNetCoreApi.Data.Repositories;
using TalabatWebAspDotNetCoreApi.Data.Repositories.Account;
using TalabatWebAspDotNetCoreApi.Data.Repositories.DeliveryData;
using TalabatWebAspDotNetCoreApi.Data.Repositories.MenuItemData;
using TalabatWebAspDotNetCoreApi.Data.Repositories.OrderData;
using TalabatWebAspDotNetCoreApi.Data.Repositories.OrderItemData;
using TalabatWebAspDotNetCoreApi.Data.Repositories.Resturant;
using TalabatWebAspDotNetCoreApi.Data.Repositories.ReviewData;
using TalabatWebAspDotNetCoreApi.Service;

namespace TalabatWebAspDotNetCoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add Register DbContext file
            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("TalabatApiConnectionString"))
            );

            // register role based authorization
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // register (IServiceAccount, Register) and (IServiceAccount , Login)
            builder.Services.AddScoped<IServiceAccount<DtoRegister>, Register>();
            builder.Services.AddScoped<IServiceAccount<DtoLogin>, Login>();

            // register (IServiceResturant , ServiceResturant)
            builder.Services.AddScoped<IServiceResturant, ServiceResturant>();

            // register (IServiceMenuItem , ServiceMenuItem)
            builder.Services.AddScoped<IServiceMenuItem, ServiceMenuItem>();

            // register (IServiceOrder , ServiceOrder)
            builder.Services.AddScoped<IServiceData<DtoOrder>, ServiceOrder>();

            // register (IServiceOrderItem , ServiceOrderItem)
            builder.Services.AddScoped<IServiceOrderItem, ServiceOrderItem>();

            // register (IServicePayment , ServicePayment)
            builder.Services.AddScoped<IServicePayment, ServicePayment>();

            // register (IServiceReview , ServiceReview)
            builder.Services.AddScoped<IServiceReview, ServiceReview>();

            // register (IServiceDelivery , ServiceDelivery)
            builder.Services.AddScoped<IServiceDelivery, ServiceDelivery>();

            // Configure JWT authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Value,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:TokenKey").Value!))
                };
            });


            var app = builder.Build();

            // register roles
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                services.InitializeSomeRole().Wait();
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
