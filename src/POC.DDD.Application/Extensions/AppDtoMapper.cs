using POC.DDD.Application.DTOs.Input;
using POC.DDD.Application.DTOs.Output;
using POC.DDD.Domain.Entities;

namespace POC.DDD.Application.Extensions
{
    public static class AppDtoMapper
    {
        public static BusinessResponse ToResponse(this Business business, int? businessId = null)
        {
            if (business == null) return null;

            return new BusinessResponse
            {
                Id = businessId ?? business.Id,
                Name = business.Name
            };
        }

        public static Business ToDomain(this BusinessRequest businessRequest)
        {
            if (businessRequest == null) return null;

            return Business.CreateNew(businessRequest.Name);
        }

        public static Business ToDomain(this BusinessRequest businessRequest, int id)
        {
            if (businessRequest == null) return null;

            return Business.LoadExisting(id, businessRequest.Name);
        }
    }
}
