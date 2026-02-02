using EmailService;
using Microsoft.AspNetCore.Components;

namespace SendMailBlazor.Components.Pages
{
    public partial class Home
    {
        // Fields
        /*
            It is important to have subdomains for different areas of 
         */
        private const string _SENDER_ADDRESS = "tester@testing.worrynotsmp.xyz"; // Namecheap domain I had lying around - housebuilder21
        
        string recipient = string.Empty;
        string message = string.Empty;
        bool awaitingMessage = false;

        string SuccessMsg { get; set; } = string.Empty;

        string ErrorDescription { get; set; } = string.Empty;

        // Properties
        [Inject] // Inject the mailing service.
        IEmailingService EmailService { get; set; } = default!;

        /// <summary>
        /// Button function to send the email. The written recipient and message gets passed to the email service for sending.
        /// </summary>
        public async void SendMail()
        {
            try
            {
                // See Components/EmailTemplates/test-html.html to see the message itsel.
                string messageDocument = "Components/EmailTemplates/test-html.html";
                /*
                    NOTICE: It is important to add a text version of the email you're sending. It builds domain trust (less likely for
                    the email to end up in the spam folder) and ensures that the message is readable if the recipient's email app
                    cannot view HTML versions of email.
                */
                string textVersion = $"Hello there!\nThis email is a test message sent from a Blazor app using Resend's email API. The sender has an additional message below:\n{message}";
                awaitingMessage = true;

                // The EmailMessage class has two constructors. One for manually putting in the HTML,
                // and this one to utilize an HTML file for a template.
                await EmailService.SendEmailAsync(new EmailMessage(
                    recipient, // To
                    _SENDER_ADDRESS, // From - See lines 9 - * for important information.
                    "Test Mail", // Subject
                    textVersion, // Plain Text Version
                    messageDocument, // Filepath to Template
                    new Dictionary<string, object> // Variables to Replace
                    {
                        { "MESSAGE", message }
                    }
                    ));

                SuccessMsg = "Mail sent!";
                awaitingMessage = false;
                StateHasChanged(); // We need to put this in, otherwise the success message doesn't get shown. :P
                Console.WriteLine("Mail sent!");

            }
            catch (Exception e)
            {
                ErrorDescription = e.Message;
                awaitingMessage = false;
                StateHasChanged();
            }
        }
    }
}
