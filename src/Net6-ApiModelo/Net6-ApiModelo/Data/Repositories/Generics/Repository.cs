using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using Net6_ApiModelo.Model.Entities;
using Net6_ApiModelo.Model.Interfaces.Generics;

namespace Net6_ApiModelo.Data.Repositories.Generics
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class  //Entity, new()
    {
        //pode passar o DbContext direto tambem, e a injecação de dependencia e tipado pela seu db
        //protected readonly DbContext _dbContext;
        protected readonly ApplicationDbContext Db;  //vamos passar nosso dbcontexto customizados sem herda DbContext para fazer teste 
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ApplicationDbContext db)//, DbContext dbContext) 
        {
            //_dbContext = dbContext;
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
            await DbSet.AddAsync(entity);
            //await SaveChanges(); //se estiver usando uow então pode remover o save do repositorio 
        }

        public virtual async Task AddTask(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            //await SaveChanges();  //se estiver usando uow então pode remover o save do repositorio 
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            //await SaveChanges(); //Uow faz isso já
        }

        public virtual async Task Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            //await SaveChanges(); //Uow faz isso já
        }

        public async Task RemoverByTEntity(TEntity entity)
        {
            DbSet.Remove(entity);
            //await SaveChanges(); //Uow faz isso já     
        }

        public async Task<int> SaveChanges() //Uow faz isso já, poderia remover
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }


    }
}
