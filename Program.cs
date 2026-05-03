using final_crud.Data;
using final_crud.Repositories;
using final_crud.Repositories.Interfaces;
using final_crud.Services;
using final_crud.Services.GenerateToken;
using final_crud.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton<JwtTokenService>();

// JWT AUTHENTICATION
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)

    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = "myapi",
                ValidAudience = "myapi",

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            "SUPER_SECRET_KEY_12345_MY_VERY_SECURE_KEY_2026"
                        ))
            };
    });

// AUTHORIZATION
builder.Services.AddAuthorization();

var app = builder.Build();

//app.UseHttpsRedirection();

app.UseRouting();

// IMPORTANT ORDER
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();