using Microsoft.EntityFrameworkCore;
using Net6_ApiModelo.Data;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Model.UnitOfWork
{
    public interface IUnitOfWork : IDisposable //<out TContext> where TContext : ApplicationDbContext, new()
    {
       // TContext Context { get; }
      //  void CreateTransaction();
      //  void Commit(); //sem retorno
     //   void Rollback(); //sem retorno

        Task<bool> Commit(); //return task
        Task Rollback();  //return task

       // void Save();
    }
}
