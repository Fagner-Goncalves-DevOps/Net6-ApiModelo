using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Model.Interfaces.Generics
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        void Add(TEntity entity);  // Sem retorno
        Task AddTask(TEntity entity); //retornando task

        Task Update(TEntity entity); 
        Task<TEntity?> GetById(int id);

        Task Remover(int id);      
        Task RemoverByTEntity(TEntity entity);
        Task<int> SaveChanges();   

    }
}
