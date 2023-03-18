using Microsoft.EntityFrameworkCore;
using Net6_ApiModelo.Data;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;



// Add services to the container.
builder.Services.AddControllers();

// For Entity Framework   --Registrar o contexto do banco de dados--
builder.Services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); //Precisa pacote Entity Framework SqlSever 


//podem ser registrados aqui tambem
// For Identity
// Adding Authentication
// Adding Jwt Bearer
// configure DI for application services

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
