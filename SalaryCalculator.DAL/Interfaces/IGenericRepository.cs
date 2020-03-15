using System.Collections.Generic;
using System.Threading.Tasks;
using SalaryCalculator.Domain;

namespace SalaryCalculator.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : Entity, new()
    {
        Task<T> GetAsync(int? id);
        void Create(T entity);
        Task DeleteAsync(int id);
        void Delete(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }

}
