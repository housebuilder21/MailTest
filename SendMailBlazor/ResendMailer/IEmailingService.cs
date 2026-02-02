namespace EmailService
{
    /// <summary>
    /// An interface to blueprint what email services should do in this program. 
    /// Use this to inject ResentMailer into the main program. (See line 17 in Program.cs)
    /// </summary>
    public interface IEmailingService
    {
        public Task SendEmailAsync(EmailMessage emailMessage);
    }
}
