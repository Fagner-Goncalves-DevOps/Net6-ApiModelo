using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using Net6_ApiModelo.Model.Entities;
using Net6_ApiModelo.Model.Interfaces.Generics;

namespace Net6_ApiModelo.Data.Repositories.Generics
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class  //Entity, new()
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ApplicationDbContext db) 
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async void Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task AddTask(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();    
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            await SaveChanges();
        }

        public async Task RemoverByTEntity(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();    
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }


    }
}
