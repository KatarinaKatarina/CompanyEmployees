using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        CompanyDto GetCompany(Guid companyId, bool trackChanges);
        CompanyDto CreateCompany(CompanyForCreationDto? company);
        IEnumerable<CompanyDto> GetByIds(IList<Guid> ids, bool trackChanges);
        (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection); //allows returning two retValues
        void DeleteCompany(Guid companyId, bool trackChanges);
    }
}