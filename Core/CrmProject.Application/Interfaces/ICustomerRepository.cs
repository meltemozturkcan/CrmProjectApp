
using CrmProject.Application.Features.Customers.Queries;
using CrmProject.Domain.Entities;

namespace CrmProject.Application.Interfaces
    {
        public interface ICustomerRepository
        {
            Task<Customer> GetByIdAsync(int id);
            Task<IEnumerable<Customer>> GetAllAsync();
            Task<IEnumerable<Customer>> GetFilteredAsync(GetCustomersQuery query);
            Task<int> GetTotalCountAsync(GetCustomersQuery query);
            Task<Customer> AddAsync(Customer customer);
            Task UpdateAsync(Customer customer);
            Task DeleteAsync(int id);
        }
}



