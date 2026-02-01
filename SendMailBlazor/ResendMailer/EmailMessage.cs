using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService
{
    /// <summary>
    /// FYI, the Resend package for .NET has its own <see cref="Resend.EmailMessage"/> class
    /// that is used to send emails through their API. For the interests of encapsulation
    /// (so you don't have to import Resend itself), a custom <see cref="EmailMessage"/> class will be
    /// used to create emails for the ResendMailer email service.
    /// </summary>
    public class EmailMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string HtmlBody { get; set; } = "";
        public string PlainTextBody { get; set; }

        /// <summary>
        /// Base constructor - If you wanna write the HTML message in the code, use this. 
        /// See the other constructor if you want to use an HTML file.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="plainTextBody"></param>
        public EmailMessage(string to, string from, string subject, string plainTextBody, string htmlBody)
        {
            To = to;
            From = from;
            Subject = subject;
            HtmlBody = htmlBody;
            PlainTextBody = plainTextBody;
        }

        /// <summary>
        /// Templated Email - Use this if you want to use an HTML file for a template with variables
        /// to put in.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="plainTextBody"></param>
        /// <param name="htmlDocumentPath"></param>
        /// <param name="placeholderSubstitutions"></param>
        public EmailMessage(
            string to,
            string from,
            string subject,
            string plainTextBody,
            string htmlDocumentPath,
            Dictionary<string, object> placeholderSubstitutions)
        {
            // Gather HTML into a string.
            string htmlString = File.ReadAllText(htmlDocumentPath);

            // Apply Substitutions
            foreach (var (name, value) in placeholderSubstitutions)
            {
                htmlString = htmlString.Replace($"[{name}]", (string?)value);
            }

            // TODO: Check and throw exception for missing variables in the template.

            // Insert Values
            To = to;
            From = from;
            Subject = subject;
            PlainTextBody = plainTextBody;
            HtmlBody = htmlString;
        }
    }
}
