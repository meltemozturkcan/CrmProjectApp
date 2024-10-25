using CrmProject.Application.Features.Customers.Queries;
using CrmProject.Application.Interfaces;
using CrmProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmProject.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(AppDbContext context, ILogger<CustomerRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetFilteredAsync(GetCustomersQuery query)
        {
            var customers = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(query.NameFilter))
            {
                customers = customers.Where(c =>
                    c.FirstName.Contains(query.NameFilter) ||
                    c.LastName.Contains(query.NameFilter));
            }

            if (!string.IsNullOrEmpty(query.EmailFilter))
            {
                customers = customers.Where(c => c.Email.Contains(query.EmailFilter));
            }

            if (!string.IsNullOrEmpty(query.RegionFilter))
            {
                customers = customers.Where(c => c.Region == query.RegionFilter);
            }

            if (query.FromDate.HasValue)
            {
                customers = customers.Where(c => c.RegistrationDate >= query.FromDate);
            }

            return await customers
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync(GetCustomersQuery query)
        {
            var customers = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(query.NameFilter))
            {
                customers = customers.Where(c =>
                    c.FirstName.Contains(query.NameFilter) ||
                    c.LastName.Contains(query.NameFilter));
            }

            if (!string.IsNullOrEmpty(query.EmailFilter))
            {
                customers = customers.Where(c => c.Email.Contains(query.EmailFilter));
            }

            if (!string.IsNullOrEmpty(query.RegionFilter))
            {
                customers = customers.Where(c => c.Region == query.RegionFilter);
            }

            if (query.FromDate.HasValue)
            {
                customers = customers.Where(c => c.RegistrationDate >= query.FromDate);
            }

            return await customers.CountAsync();
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await GetByIdAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
