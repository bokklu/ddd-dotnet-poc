using POC.DDD.Application.DTOs.Input;
using POC.DDD.Application.DTOs.Output;
using POC.DDD.Shared;

namespace POC.DDD.Application.Services.Abstractions
{
    public interface IBusinessService
    {
        Task<Result<BusinessResponse>> GetAsync(int id);
        Task<Result<BusinessResponse>> CreateAsync(BusinessRequest request);
        Task<Result<BusinessResponse>> UpdateAsync(int id, BusinessRequest request);
        Task<Result<int>> DeleteAsync(int id);
    }
}
