using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using azure_key_vault.Models;
using azure_key_vault.Services;

namespace azure_key_vault.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppConfig _appConfig;

        public HomeController(IOptions<AppConfig> appConfig)
        {
            _appConfig = appConfig.Value;
        }

        public async Task<IActionResult> Index()
        {
            var keyValue = await KeyVault.Get();
            _appConfig.my_random_third_party_usernmae = keyValue.Value;
            return View(_appConfig);
        }
    }
}
