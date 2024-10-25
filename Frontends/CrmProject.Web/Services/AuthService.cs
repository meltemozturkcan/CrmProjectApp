using System.Net.Http.Json;
using System.Text.Json;

namespace CrmProject.Web.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string username, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AuthService> _logger;
        private readonly IConfiguration _configuration;

        public AuthService(
            HttpClient httpClient,
            ILogger<AuthService> logger,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            _configuration = configuration;

            var apiUrl = _configuration["ApiSettings:BaseUrl"];
            _logger.LogInformation("API URL: {ApiUrl}", apiUrl);
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            try
            {
                _logger.LogInformation("Attempting to login for user: {Username}", username);

                var loginRequest = new LoginRequest
                {
                    Username = username,
                    Password = password
                };

                var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);

                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("API Response: {Response}", responseContent);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent);
                    if (loginResponse?.Token != null)
                    {
                        _logger.LogInformation("Login successful for user: {Username}", username);
                        return loginResponse.Token;
                    }
                    throw new Exception("Token is null in response");
                }

                _logger.LogWarning("Login failed with status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Login failed: {response.StatusCode} - {responseContent}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login error for user: {Username}", username);
                throw new Exception("An error occurred during login. Please try again.", ex);
            }
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}