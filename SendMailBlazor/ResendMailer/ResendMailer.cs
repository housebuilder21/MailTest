using Resend;

namespace EmailService
{
    public class ResendMailer
    {
        // Fields
        private readonly string _SENDER_ADDRESS = "tester@testing.worrynotsmp.xyz"; // Namecheap domain I had lying around - housebuilder21

        // Properties
        IResend Resend { get; set; }

        // Constructor
        public ResendMailer(string apiKey)
        {
            Resend = ResendClient.Create(apiKey);
        }

        // Methods
        public async Task<bool> SendEmail(string recipient, string message)
        {
            var resp = await Resend.EmailSendAsync(new EmailMessage()
            {
                From = _SENDER_ADDRESS,
                To = recipient,
                Subject = "Test Email",
                HtmlBody = message,
            });

            if (resp.Success) return true;
            
            throw resp.Exception;
        }
    }
}
