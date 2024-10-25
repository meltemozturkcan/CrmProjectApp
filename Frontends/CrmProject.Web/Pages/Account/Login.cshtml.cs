using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using CrmProject.Web.Services;

namespace CrmProject.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(
            IAuthService authService,
            ILogger<LoginModel> logger)
        {
            _authService = authService;
            _logger = logger;
            Input = new InputModel();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Username is required")]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me")]
            public bool RememberMe { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Attempting login for user: {Username}", Input.Username);

                    var token = await _authService.LoginAsync(Input.Username, Input.Password);

                    if (!string.IsNullOrEmpty(token))
                    {
                        var cookieOptions = new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            SameSite = SameSiteMode.Lax,
                            Expires = DateTime.UtcNow.AddHours(8)
                        };

                        Response.Cookies.Append("AuthToken", token, cookieOptions);
                        _logger.LogInformation("Login successful for user: {Username}", Input.Username);
                        return LocalRedirect(returnUrl);
                    }

                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login error for user: {Username}", Input.Username);
                ModelState.AddModelError(string.Empty, "An error occurred during login. Please try again.");
            }

            return Page();
        }
    }
}