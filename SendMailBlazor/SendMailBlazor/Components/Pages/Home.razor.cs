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
        [Inject] // Inject the mailing service.
        ResendMailer ResendMailer { get; set; } = default!;

        /// <summary>
        /// Button function to send the email. The written recipient and message gets passed to the email service for sending.
        /// </summary>
        public async void SendMail()
        {
            try
            {
                string fullMessage = $"<p><strong>Hello there!</strong></p>\n<p>This email is a test message sent from a Blazor app using Resend's email API. The sender has an additional message below:</p>\n{message}";

                if (await ResendMailer.SendEmail(recipient, fullMessage))
                {
                    SuccessMsg = "Mail sent!";
                    StateHasChanged(); // We need to put this in, otherwise the success message doesn't get shown. :P
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
