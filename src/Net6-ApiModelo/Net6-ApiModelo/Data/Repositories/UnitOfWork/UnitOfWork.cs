using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Net6_ApiModelo.Model.Interfaces.UnitOfWork;

namespace Net6_ApiModelo.Data.Repositories.UnitOfWork
{
    //modelo simples de UnitOfWork
    public class UnitOfWork : IUnitOfWork //<TContext>, IDisposable where TContext : ApplicationDbContext, new()
    {

        private readonly ApplicationDbContext _context;


        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
        }

        public async Task<bool> Commit()
        {
            var sucess = (await _context.SaveChangesAsync()) > 0;
            return sucess;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
