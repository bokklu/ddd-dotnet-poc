using POC.DDD.Domain.Entities;
using POC.DDD.Infra.DTOs;

namespace POC.DDD.Infra.Extensions
{
    public static class InfraDtoMapper
    {
        public static BusinessDto ToDto(this Business business)
        {
            if (business == null) return null;

            return new BusinessDto { Id = business.Id, Name = business.Name };
        }

        public static Business ToDomain(this BusinessDto businessEntity)
        {
            if (businessEntity == null) return null;

            return Business.LoadExisting(businessEntity.Id, businessEntity.Name);
        }
    }
}
