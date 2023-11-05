using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzWebApp.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			string kvUri = "";
			SecretClient client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
			var secret = client.GetSecretAsync("secretColour").Result.Value;
			ViewData["secretColour"] = secret.Value;
		}
	}
}