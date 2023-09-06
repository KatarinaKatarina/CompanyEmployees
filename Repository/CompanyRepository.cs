using Contracts;
using Entities.Models;

namespace Repository
{
    internal class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToList();

        public Company? GetCompany(Guid companyId, bool trackChanges) =>
            FindByCondition(company => company.Id.Equals("3d490a70-94ce-4d15-9494-5248280c2ce2"), trackChanges)
                .SingleOrDefault();
    }
}
