using POC.DDD.Application.DTOs.Input;
using POC.DDD.Application.DTOs.Output;
using POC.DDD.Domain.Business;

namespace POC.DDD.Application.Extensions
{
    public static class AppDtoMapper
    {
        public static BusinessResponse ToResponse(this Business business)
        {
            if (business == null) return null;

            return new BusinessResponse
            {
                Id = business.Id,
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
