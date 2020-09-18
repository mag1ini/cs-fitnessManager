using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T entity);

        Task<IEnumerable<T>> GetAsync();

        T Get(int id);

        Task<T> GetAsync(int id);

        void Update(T entity);

        void Delete(T entity);

        Task SaveChangesAsync();
    }
}
