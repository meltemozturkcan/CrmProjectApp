using AutoMapper;
using CrmProject.Application.Features.Customers.Commands;
using CrmProject.Application.Interfaces;
using CrmProject.Domain.Entities;
using CrmProject.Web.Pages.Customers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrmProject.Web.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(
            ICustomerRepository customerRepository,
            IMapper mapper,
            ILogger<CreateModel> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [BindProperty]
        public CreateCustomerViewModel Customer { get; set; }

        public IActionResult OnGet()
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // ViewModel'den Command'e mapping
                var command = _mapper.Map<CreateCustomerCommand>(Customer);

                // Command'den Domain modele mapping ve kaydetme
                var customerEntity = _mapper.Map<Customer>(command);
                await _customerRepository.AddAsync(customerEntity);

                _logger.LogInformation("Customer created successfully: {Email}", Customer.Email);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating customer");
                ModelState.AddModelError("", "An error occurred while creating the customer.");
                return Page();
            }
        }
    }
}
