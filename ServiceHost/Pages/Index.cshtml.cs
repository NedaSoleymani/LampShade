using _0_Framework.Application.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        public readonly ILogger<IndexModel> _logger;
        private readonly IEmailService _emailService;

        public IndexModel(IEmailService emailService) 
        {
            _emailService = emailService;
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _emailService.SendEmail("hello", "hello,how are you", "Test@gmail.com");
        }
    }
}