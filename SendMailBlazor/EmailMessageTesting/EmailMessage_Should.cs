using EmailService;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace EmailMessageTesting
{
    /// <summary>
    /// Unit Testing for the EmailMessage class. This is mostly testing 
    /// if the input correctly outputs the desired HTML.
    /// </summary>
    public class EmailMessage_Should
    {
        #region Successful Tests

        [Fact]
        public void Substitute_Correctly()
        {
            // Arrange
            string to = "testing@email.com";
            string from = "testing@email.com";
            string subject = "Test Email";
            string textBody = $"Hello there!\nThis email is a test message sent from a Blazor app using Resend's email API. The sender has an additional message below:Hello world!";
            string htmlPath = "../../../test-template.html";
            EmailMessage emailMessage;
            string correctHtml = File.ReadAllText("../../../test-template-correct.html");

            // Act
            emailMessage = new EmailMessage(to, from, subject, textBody, htmlPath, new Dictionary<string, object>{
                    { "MESSAGE", "Hello world!" }
                });

            // Assert
            emailMessage.HtmlBody.Should().Be(correctHtml);
        }

        #endregion
    }
}
