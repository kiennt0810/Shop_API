using Microsoft.EntityFrameworkCore;
using Shop_API.Context;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Reflection.Emit;
using Shop_API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shop_API.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((hosts) => true)
        .WithExposedHeaders("*"));
});


builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnStr"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.Configure<SystemParam>(builder.Configuration.GetSection("SystemParam"));
var secretKey = builder.Configuration.GetSection("SystemParam")["ApiSecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        //tu cap token
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateActor = false,
                        ValidateLifetime = true,
                        //ky vao token
                        ValidateIssuerSigningKey = false,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                        ClockSkew = TimeSpan.Zero
                    };
                });

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Repositories
builder.Services.AddScoped<IUnitOfWork, HttpUnitOfWork>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CORSPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
