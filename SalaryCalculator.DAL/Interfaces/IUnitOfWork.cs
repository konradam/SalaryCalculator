using System.Threading.Tasks;

namespace SalaryCalculator.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
    }
}
