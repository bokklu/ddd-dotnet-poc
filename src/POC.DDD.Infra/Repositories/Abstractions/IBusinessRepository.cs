using POC.DDD.Domain.Business;

namespace POC.DDD.Infra.Repositories.Abstractions
{
    public interface IBusinessRepository
    {
        Task<Business> GetAsync(int id);
        Task<Business> CreateAsync(Business business);
        Task<Business> UpdateAsync(Business business);
        Task DeleteAsync(int id);
    }
}
