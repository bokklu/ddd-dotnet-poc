using Microsoft.EntityFrameworkCore;
using POC.DDD.Domain.Business;
using POC.DDD.Infra.DTOs;
using POC.DDD.Infra.Extensions;
using POC.DDD.Infra.Repositories.Abstractions;

namespace POC.DDD.Infra.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly BusinessContext _businessContext;

        public BusinessRepository(BusinessContext businessContext)
        {
            _businessContext = businessContext;
        }

        public async Task<Business> GetAsync(int id)
        {
            var businessEntity = await _businessContext.Businesses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return businessEntity.ToDomain();
        }

        public async Task<Business> CreateAsync(Business business)
        {
            var createdBusiness = await _businessContext.Businesses.AddAsync(business.ToDto());

            await _businessContext.SaveChangesAsync();

            return createdBusiness.Entity.ToDomain();
        }

        public async Task<Business> UpdateAsync(Business business)
        {
            var updatedBusiness = _businessContext.Businesses.Update(business.ToDto());

            await _businessContext.SaveChangesAsync();

            return updatedBusiness.Entity.ToDomain();
        }

        public async Task DeleteAsync(int id)
        {
            _businessContext.Businesses.Remove(new BusinessDto { Id = id });

            await _businessContext.SaveChangesAsync();
        }
    }
}
