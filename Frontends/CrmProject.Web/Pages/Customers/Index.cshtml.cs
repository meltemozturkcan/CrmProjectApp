using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrmProject.Application.ViewModels;
using CrmProject.Application.Interfaces;
using AutoMapper;
using CrmProject.Application.Features.Customers.Queries;
using CrmProject.Web.Pages.Customers.Models;

namespace CrmProject.Web.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<IndexModel> _logger;
        private readonly IMapper _mapper;

        public IndexModel(
            ICustomerRepository customerRepository,
            ILogger<IndexModel> logger,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [BindProperty(SupportsGet = true)]
        public Application.ViewModels.CustomerFilterModel Filter { get; set; } = new Application.ViewModels.CustomerFilterModel();

        public List<CustomerViewModel> Customers { get; set; } = new List<CustomerViewModel>();
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;

        public async Task OnGetAsync(int? page)
        {
            try
            {
                CurrentPage = page ?? 1;

                var query = new GetCustomersQuery(
                    Filter?.NameFilter,
                    Filter?.EmailFilter,
                    Filter?.RegionFilter,
                    Filter?.FromDate,
                    null,
                    CurrentPage,
                    PageSize
                );

                var customerEntities = await _customerRepository.GetFilteredAsync(query);
                Customers = _mapper.Map<List<CustomerViewModel>>(customerEntities);

                var totalCustomers = await _customerRepository.GetTotalCountAsync(query);
                TotalPages = (int)Math.Ceiling(totalCustomers / (double)PageSize);

                _logger.LogInformation("Retrieved {Count} customers with filter - Name: {Name}, Region: {Region}",
                    Customers.Count,
                    Filter?.NameFilter ?? "none",
                    Filter?.RegionFilter ?? "none");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving customers");
                TempData["Error"] = "An error occurred while retrieving customers.";
                Customers = new List<CustomerViewModel>();
            }
        }
    }
}