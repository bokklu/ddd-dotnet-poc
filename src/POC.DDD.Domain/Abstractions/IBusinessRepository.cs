using POC.DDD.Domain.Entities;

namespace POC.DDD.Domain.Abstractions
{
    public interface IBusinessRepository
    {
        Task<Business> GetAsync(int id);
        Task<int> CreateAsync(Business business);
        Task UpdateAsync(Business business);
        Task DeleteAsync(int id);
    }
}
