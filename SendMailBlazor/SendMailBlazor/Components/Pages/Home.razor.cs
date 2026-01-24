using EmailService;
using Microsoft.AspNetCore.Components;

namespace SendMailBlazor.Components.Pages
{
    public partial class Home
    {
        // Fields
        string SuccessMsg { get; set; } = string.Empty;

        // Properties
        [Inject]
        ResendMailer ResendMailer { get; set; }

        public async void SendMail()
        {
            if (await ResendMailer.SendEmail())
            {
                Console.WriteLine("Mail sent!");
                SuccessMsg = "Mail sent!";
            }
        }
    }
}
