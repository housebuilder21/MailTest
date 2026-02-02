using Resend;

namespace EmailService
{
    /// <summary>
    /// An email service that utilizes the Resend API to send mail. This is where the magic happens.
    /// </summary>
    public class ResendMailer : IEmailingService
    {
        // Fields
        //private readonly string _SENDER_ADDRESS = "tester@testing.worrynotsmp.xyz"; // Namecheap domain I had lying around - housebuilder21

        // Properties
        IResend Resend { get; set; }

        // Constructor
        // API Key is put in via Program.cs in lines 10-17.
        public ResendMailer(string apiKey)
        {
            Resend = ResendClient.Create(apiKey);
        }

        // Methods
        /// <summary>
        /// Sends out an email to the given recipient with a message.
        /// This is the base method used to send emails. See the template
        /// </summary>
        /// <param name="recipient">The email address to send to.</param>
        /// <param name="message"></param>
        /// <exception cref="Resend.ResendException">Throws if Resend couldn't send the email.</exception>
        /// <returns>True if the email was sent successfully. Throws an Exception otherwise, featuring information from the failure response.</returns>
        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            try
            {
                var resp = await Resend.EmailSendAsync(new Resend.EmailMessage()
                {
                    From = emailMessage.From,
                    To = emailMessage.To,
                    Subject = emailMessage.Subject,
                    HtmlBody = emailMessage.HtmlBody,
                    TextBody = emailMessage.PlainTextBody,
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
