using Microsoft.EntityFrameworkCore;
using Net6_ApiModelo.Data;
using Net6_ApiModelo.Data.Repositories.Generics;
using Net6_ApiModelo.Data.Repositories.UnitOfWork;
using Net6_ApiModelo.Model.Entities;
using Net6_ApiModelo.Model.Interfaces.Generics;
using Net6_ApiModelo.Model.Interfaces.UnitOfWork;

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

//Data Uow
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); //uow concrete, simples sem modelagen enviado commit, não for usar deixar comentando 

// se for usar no repostorio dbcontext direto sem herança então usa type of, se não passo dbcontext no UoW
//builder.Services.AddScoped<IUnitOfWorkGenerics<ApplicationDbContext>, UnitOfWorkGenerics<ApplicationDbContext>>(); //configurar para pegar dbcontexto testar
builder.Services.AddScoped(typeof(IUnitOfWorkGenerics<>), typeof(UnitOfWorkGenerics<>)); //configurar repositorio generico usando "tipo de"



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
