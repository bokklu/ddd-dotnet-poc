using Microsoft.AspNetCore.Mvc;
using POC.DDD.Application.DTOs.Input;
using POC.DDD.Application.Services.Abstractions;

namespace POC.DDD.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : BaseController
    {
        private readonly IBusinessService _businessService;

        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var businessResult = await _businessService.GetAsync(id);

            return businessResult.Match(Ok, HandleResultError);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BusinessRequest createBusinessRequest)
        {
            var createBusinessResult = await _businessService.CreateAsync(createBusinessRequest);

            return createBusinessResult
                .Match(
                    success => CreatedAtAction(nameof(Get), new { id = success.Id }, success),
                    HandleResultError
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BusinessRequest updateBusinessRequest)
        {
            var updateBusinessResult = await _businessService.UpdateAsync(id, updateBusinessRequest);

            return updateBusinessResult.Match(Ok, HandleResultError);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteBusinessResult = await _businessService.DeleteAsync(id);

            return deleteBusinessResult.Match(_ => NoContent(), HandleResultError);
        }
    }
}
