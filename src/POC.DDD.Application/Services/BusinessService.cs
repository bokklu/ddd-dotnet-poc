using FluentValidation;
using POC.DDD.Application.Abstractions;
using POC.DDD.Application.DTOs.Input;
using POC.DDD.Application.DTOs.Output;
using POC.DDD.Application.Extensions;
using POC.DDD.Domain.Abstractions;
using POC.DDD.Shared;

namespace POC.DDD.Application.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly IValidator<BusinessRequest> _businessRequestValidator;

        public BusinessService(
            IBusinessRepository businessRepository, 
            IValidator<BusinessRequest> businessRequestValidator)
        {
            _businessRepository = businessRepository;
            _businessRequestValidator = businessRequestValidator;
        }

        public async Task<Result<BusinessResponse>> GetAsync(int id)
        {
            if (id <= 0)
            {
                return Result<BusinessResponse>.Fail(new ResultError(ResultErrorStatus.BadRequest, $"Invalid Business Id: {id} provided."));
            }

            var business = await _businessRepository.GetAsync(id);

            if (business == null)
            {
                return Result<BusinessResponse>.Fail(new ResultError(ResultErrorStatus.NotFound, $"Business Id: {id} does not exist."));
            }

            return Result<BusinessResponse>.Success(business.ToResponse());
        }

        public async Task<Result<BusinessResponse>> CreateAsync(BusinessRequest request)
        {
            var validationResult = _businessRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<BusinessResponse>.Fail(new ResultError(ResultErrorStatus.BadRequest, string.Join(", ", validationResult.Errors)));
            }

            var createdBusiness = await _businessRepository.CreateAsync(request.ToDomain());

            return Result<BusinessResponse>.Success(createdBusiness.ToResponse());
        }

        public async Task<Result<BusinessResponse>> UpdateAsync(int id, BusinessRequest request)
        {
            if (id <= 0)
            {
                return Result<BusinessResponse>.Fail(new ResultError(ResultErrorStatus.BadRequest, $"Invalid Business Id: {id} provided."));
            }

            var validationResult = _businessRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<BusinessResponse>.Fail(new ResultError(ResultErrorStatus.BadRequest, string.Join(", ", validationResult.Errors)));
            }

            var business = await _businessRepository.GetAsync(id);

            if (business == null)
            {
                return Result<BusinessResponse>.Fail(new ResultError(ResultErrorStatus.NotFound, $"Business Id: {id} does not exist."));
            }

            var createdBusiness = await _businessRepository.UpdateAsync(request.ToDomain(id));

            return Result<BusinessResponse>.Success(createdBusiness.ToResponse());
        }

        public async Task<Result<int>> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                return Result<int>.Fail(new ResultError(ResultErrorStatus.BadRequest, $"Invalid Business Id: {id} provided."));
            }

            var business = await _businessRepository.GetAsync(id);

            if (business == null)
            {
                return Result<int>.Fail(new ResultError(ResultErrorStatus.NotFound, $"Business Id: {id} does not exist."));
            }

            await _businessRepository.DeleteAsync(id);

            return Result<int>.Success(id);
        }
    }
}
