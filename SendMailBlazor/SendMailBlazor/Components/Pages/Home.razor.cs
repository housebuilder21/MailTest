using EmailService;
using Microsoft.AspNetCore.Components;

namespace SendMailBlazor.Components.Pages
{
    public partial class Home
    {
        // Fields
        string SuccessMsg { get; set; } = string.Empty;

        string ErrorDescription { get; set; }

        // Properties
        [Inject]
        ResendMailer ResendMailer { get; set; }

        public async void SendMail()
        {
            try
            {
                if (await ResendMailer.SendEmail())
                {
                    SuccessMsg = "Mail sent!";
                    Console.WriteLine("Mail sent!");
                }
            }
            catch (Exception e)
            {
                ErrorDescription = e.Message;
            }
        }
    }
}
