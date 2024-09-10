using Catalog.API.Application.Contract;
using Catalog.API.Infrastructure.Persistence;
using Catalog.API.Infrastructure.Persistence.Repositiories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<CatalogContext>(options =>
{

    if (builder.Environment.IsDevelopment())
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Catalog"));
    }
    else
    {
        var userId = builder.Configuration["UserId"].ToString();
        var password = builder.Configuration["Password"].ToString();
        var connectionStringBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("Catalog"));
        connectionStringBuilder.UserID = userId;
        connectionStringBuilder.Password = password;

        options.UseSqlServer(builder.Configuration.GetConnectionString(
            connectionStringBuilder.ConnectionString));
    }
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(policy => 
    {
        if(builder.Environment.IsDevelopment())
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .WithExposedHeaders("X-PagingData");
        }
        else 
        {
            policy.WithOrigins("www.domain1.com", "www.domain2.com")
                  .WithMethods("GET", "POST")
                  .WithHeaders("h1", "h2")
                  .WithExposedHeaders("X-PagingData");
        }
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program 
{}
