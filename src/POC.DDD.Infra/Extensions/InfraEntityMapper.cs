using POC.DDD.Domain.Business;
using POC.DDD.Infra.Entities;

namespace POC.DDD.Infra.Extensions
{
    public static class InfraEntityMapper
    {
        public static BusinessEntity ToEntity(this Business business)
        {
            if (business == null) return null;

            return new BusinessEntity { Id = business.Id, Name = business.Name };
        }

        public static Business ToDomain(this BusinessEntity businessEntity)
        {
            if (businessEntity == null) return null;

            return Business.LoadExisting(businessEntity.Id, businessEntity.Name);
        }
    }
}
