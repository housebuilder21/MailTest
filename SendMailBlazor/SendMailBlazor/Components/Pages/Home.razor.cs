using EmailService;
using Microsoft.AspNetCore.Components;

namespace SendMailBlazor.Components.Pages
{
    public partial class Home
    {
        // Fields
        string recipient = string.Empty;
        string message = string.Empty;
        
        string SuccessMsg { get; set; } = string.Empty;

        string ErrorDescription { get; set; } = string.Empty;

        // Properties
        [Inject]
        ResendMailer ResendMailer { get; set; } = default!;

        public async void SendMail()
        {
            try
            {
                string fullMessage = $"<p><strong>Hello there!</strong></p>\n<p>This email is a test message sent from a Blazor app using Resend's email API. The sender has an additional message below:</p>\n{message}";

                if (await ResendMailer.SendEmail(recipient, fullMessage))
                {
                    SuccessMsg = "Mail sent!";
                    StateHasChanged();
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
