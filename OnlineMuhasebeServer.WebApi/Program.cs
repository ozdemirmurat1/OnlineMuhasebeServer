using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OnlineMuhasebeServer.Application;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Persistence;
using OnlineMuhasebeServer.Persistence.Context;
using OnlineMuhasebeServer.Persistence.Services.AppServices;
using OnlineMuhasebeServer.Presentation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => 
                  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddIdentity<AppUser,AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<ICompanyService, CompanyService>();

//builder.Services.AddMediatR(typeof(OnlineMuhasebeServer.Application.AssemblyReference).Assembly);
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(OnlineMuhasebeServer.Application.AssemblyReference).Assembly); });

builder.Services.AddAutoMapper(typeof(OnlineMuhasebeServer.Persistence.AssemblyReference).Assembly);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(OnlineMuhasebeServer.Persistence.AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat="JWT",
        Name="JWT Authentication",
        In=ParameterLocation.Header,
        Type=SecuritySchemeType.Http,
        Scheme=JwtBearerDefaults.AuthenticationScheme,
        Description="Put **_ONLY_** your JWT Bearer token on textbox below!",
        Reference=new OpenApiReference
        {
            Id=JwtBearerDefaults.AuthenticationScheme,
            Type=ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSecurityScheme,Array.Empty<string>() }
    });
});

var app = builder.Build();

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
