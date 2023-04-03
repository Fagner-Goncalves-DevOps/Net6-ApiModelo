using Microsoft.EntityFrameworkCore;
using Net6_ApiModelo.Data;
using Net6_ApiModelo.Data.Repositories.Generics;
using Net6_ApiModelo.Data.Repositories.UnitOfWork;
using Net6_ApiModelo.Model.Entities;
using Net6_ApiModelo.Model.Interfaces.Generics;
using Net6_ApiModelo.Model.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;



// Add services to the container.
builder.Services.AddControllers();

// For Entity Framework   --Registrar o contexto do banco de dados--
builder.Services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); //Precisa pacote Entity Framework SqlSever 

// ----- Native DI Abstraction -----
builder.Services.AddScoped<ApplicationDbContext>();
//builder.Services.AddScoped<IRepository<Personagem>, Repository<Personagem>>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); //configurar repositorio generico usando "tipo de"

//Data
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); //uow simples sem modelagen enviado commit 




// ----- Authentication -----
// ----- Jwt Bearer -----
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
