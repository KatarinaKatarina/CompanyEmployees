using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesController(IServiceManager service) => _service = service; //ctor!

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");
            return Ok();
        }

        [HttpGet(Name = "GetCompanies")]
        public async Task<IActionResult> GetCompanies() //IActionResult returns retVal + status code
        {
            var companies = await _service.CompanyService.GetAllCompaniesAsync(trackChanges: false);
            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")] //setting the name for the action
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _service.CompanyService.GetCompanyAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost(Name = "CreateCompany")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto? company)
        {
            var createdCompany = await _service.CompanyService.CreateCompany(company);
            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
            // CreatedAtRoute - create status code 204 + newly created object + Location attribute in header with URI of the new entity (if there is an actionName set like on the line 14)
        }

        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var companies = await _service.CompanyService.GetByIdsAsync(ids.ToList(), trackChanges: false);
            return Ok(companies);
        }

        [HttpPost("collection")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result = await _service.CompanyService.CreateCompanyCollectionAsync(companyCollection);
            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _service.CompanyService.DeleteCompanyAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            await _service.CompanyService.UpdateCompanyAsync(id, company, trackChanges: true);
            return NoContent();
        }
    }
}
