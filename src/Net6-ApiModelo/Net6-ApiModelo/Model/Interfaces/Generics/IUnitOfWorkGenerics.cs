using Microsoft.EntityFrameworkCore;
using Net6_ApiModelo.Data;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Model.Interfaces.Generics
{
    //uma interface q implementa interfaces, passando genericos
    //TEntity seria meu contexto generico q vou passar
    public interface IUnitOfWorkGenerics<TDbContext> where TDbContext : ApplicationDbContext //DbContext  //: IDisposable //<out TContext> where TContext : ApplicationDbContext, new()
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();

        //nossos repositorio generico get e create, passando pelo UoW para acessar contexto
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IRepository<TEntity> CreateRepositoryInstance<TEntity>(TDbContext dbContext) where TEntity : class;




        // IRepository<TEntity> Repository { get; } //quero passar entidade generica aqui, poderia passar entidade non-generica
        //  IRepository<Personagem> Personagem { get; } //poderia passar entidade non-generica tambem
        //Task<bool> Commit(); //return task
        //Task Rollback();  //return task
        //TContext Context { get; }
        //void CreateTransaction();
        //void Commit(); //sem retorno
        //void Rollback(); //sem retorno
        // void Save();
    }
}
