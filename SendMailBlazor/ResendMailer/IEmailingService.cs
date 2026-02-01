namespace EmailService
{
    public interface IEmailingService
    {
        public Task SendEmailAsync(EmailMessage emailMessage);
    }
}
