using Microsoft.AspNetCore.Authentication;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Bar_Management_System.Configuration;
using Bar_Management_System;

var builder = WebApplication.CreateBuilder(args);

// Define CORS policies
const string AllowSpecificOrigins = "_myAllowSpecificOrigins";
const string AllowAllOrigins = "_myAllowAllOrigins";

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Define CORS policies

builder.Services.AddCors(options =>
{
    // Policy for specific origins (localhost:4200 in this case)
    options.AddPolicy(AllowSpecificOrigins,
        builder => builder
            .WithOrigins("http://localhost:4200", "https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials());

    // Policy for all origins (use with caution in production)
    options.AddPolicy(AllowAllOrigins,
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


builder.Services.AddDbContext<BMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddAutoMapper(typeof(MapperInitilizer));
ServiceExtensions.ConfigureApplicationServices(builder.Services, builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Choose either AllowSpecificOrigins or AllowAllOrigins based on your requirements
app.UseCors(AllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
