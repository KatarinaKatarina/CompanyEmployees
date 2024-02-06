using Entities.Models;

namespace Repository.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> employees, uint minAge, uint maxAge) =>
            employees.Where(employee => (employee.Age >= minAge && employee.Age <= maxAge));

        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return employees;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return employees.Where(employee => employee.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
