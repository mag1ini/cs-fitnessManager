using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFitnessManager.Db.Entities;

namespace MyFitnessManager.Db.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T entity);

        Task<IEnumerable<T>> GetAsync();

        Task<T> GetAsync(int id);

        void Update(T entity);

        void Delete(T entity);

        Task SaveChangesAsync();
    }
}
