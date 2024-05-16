﻿using System;
using System.Text.Json.Serialization;
using LAB1_WEB2_12201039.Data;
//using LAB1_WEB2_12201039.Services;
using Microsoft.EntityFrameworkCore;
using LAB1_WEB2_12201039.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
var _logger = new LoggerConfiguration()
 .WriteTo.Console()// ghi ra console
 .WriteTo.File("Logs/Book_log.txt", rollingInterval: RollingInterval.Minute) //ghi ra file lưu trong thư mục Logs
 .MinimumLevel.Information()
 .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(_logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Book API",
        Version = "v1"
    });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new
   OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type= ReferenceType.SecurityScheme,
                    Id= JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Oauth2",
                Name =JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


// Register Library Service to use it with Dependency Injection in Controllers
//builder.Services.AddTransient<ILibraryService, LibraryService>();


// Register database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<BookAuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookAuthConnection")));

builder.Services.AddScoped<IBookRepository, SQLBookRepository>();
builder.Services.AddScoped<IAuthorRepository, SQLAuthorRepository>();
builder.Services.AddScoped<IPublisherRepository, SQLPublisherRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IImageRepository, LocalImageRepository>();


// config identity user
builder.Services.AddIdentityCore<IdentityUser>()
 .AddRoles<IdentityRole>()
 .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Book")
 .AddEntityFrameworkStores<BookAuthDbContext>()
 .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequireDigit = false;// Yêu cầu về password chứa ký số không?
    option.Password.RequireLowercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequiredLength = 6;
    option.Password.RequiredUniqueChars = 1;
});

// khai báo service Authentication + using thu vien
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>option.TokenValidationParameters = new TokenValidationParameters
 {
     ValidateIssuer = true,
     ValidateAudience = true,
     ValidateLifetime = true,
     ValidateIssuerSigningKey = true,
     ValidIssuer = builder.Configuration["Jwt:Issuer"],
     ValidAudience = builder.Configuration["Jwt:Audience"],
     ClockSkew = TimeSpan.Zero,
     IssuerSigningKey = new SymmetricSecurityKey(
 Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
 });

var app = builder.Build();

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