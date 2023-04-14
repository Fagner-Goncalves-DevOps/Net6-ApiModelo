using Microsoft.EntityFrameworkCore;
using Net6_ApiModelo.Model.Entities;
using Net6_ApiModelo.Model.Interfaces.Generics;

namespace Net6_ApiModelo.Data.Repositories.Generics
{
    public class UnitOfWorkGenerics<TDbContext> : IUnitOfWorkGenerics<TDbContext> where TDbContext : ApplicationDbContext//DbContext
    {
        private readonly TDbContext _dbContext;
        private Dictionary<Type, object?> _resositories; // = new Dictionary<Type, object>(); pode passar direto aqui

        public UnitOfWorkGenerics(TDbContext dbContext) 
        {
            this._dbContext = dbContext;
            _resositories = new Dictionary<Type, object?>();
        }



        public IRepository<TEntity> CreateRepositoryInstance<TEntity>(TDbContext dbContext) where TEntity : class
        {
            Repository<TEntity> repoInstance = null;

            try
            {
                repoInstance = new Repository<TEntity>(dbContext); //não acetou dbcontexto herdado apenas direto se usar DbContext 
            }
            catch (ArgumentException ex)
            {

                throw new ArgumentException(ex.Message);
            }
            return repoInstance;
        }



        public IRepository<TEntity>? GetRepository<TEntity>() where TEntity : class
        {
            IRepository<TEntity> repositoryInstance = null;

            try
            {
                if (_resositories.ContainsKey(typeof(TEntity))) 
                { 
                    return _resositories[typeof(TEntity)] as IRepository<TEntity>;
                }
                else
                {
                    repositoryInstance = CreateRepositoryInstance<TEntity>(_dbContext);
                    _resositories.Add(typeof(TEntity), repositoryInstance);
                }
            }
            catch (ArgumentException ex)
            {

                throw ex;
            }
            return repositoryInstance;
        }




        public int SaveChanges()
        {
            //pode usar try com catch se preferir
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            //pode usar try com catch se preferir
            return await _dbContext.SaveChangesAsync();
        }
    }
}
