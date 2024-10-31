using POC.DDD.Domain.Entities;

namespace POC.DDD.Domain.Abstractions
{
    public interface IBusinessRepository
    {
        Task<Business> GetAsync(int id);
        Task<Business> CreateAsync(Business business);
        Task<Business> UpdateAsync(Business business);
        Task DeleteAsync(int id);
    }
}
