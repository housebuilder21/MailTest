using Resend;

namespace EmailService
{
    public class ResendMailer
    {
        // Properties
        IResend Resend { get; set; }

        // Constructor
        public ResendMailer(string apiKey)
        {
            Resend = ResendClient.Create(apiKey);
        }

        // Methods
        public async Task<bool> SendEmail()
        {
            var resp = await Resend.EmailSendAsync(new EmailMessage()
            {
                From = "onboarding@resend.dev",
                To = "dr.delpod@gmail.com",
                Subject = "Hello World",
                HtmlBody = "<p>Congrats on sending your <strong>first email</strong>!</p>",
            });

            return resp.Success;
        }
    }
}
