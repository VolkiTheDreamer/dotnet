﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;

namespace WebAPI_SampleWeb.API
{
    public class SendFeedbackController : ApiController
    {
        public class FeedbackRequest
        {
            public int? Rating { get; set; }
            public string Feedback { get; set; }
        }

        public class FeedbackResponse
        {
            public string Status { get; set; }
            public string Message { get; set; }
        }

        [HttpPost()]
        public FeedbackResponse SendFeedback(FeedbackRequest request)
        {
            try
            {
                const string MailingAddressFrom = "app_name@contoso.com ";
                const string MailingAddressTo = "dev_team@contoso.com";
                const string SmtpHost = "smtp.contoso.com";
                const int SmtpPort = 587;
                const bool SmtpEnableSsl = true;
                const string SmtpCredentialsUsername = "username";
                const string SmtpCredentialsPassword = "password";

                var subject = "Sample App feedback, " + DateTime.Now.ToString("MMM dd, yyyy, hh:mm tt");
                var body = "Rating: " + request.Rating + "\n\n" + "Feedback:\n" + request.Feedback;

                MailMessage mail = new MailMessage(MailingAddressFrom, MailingAddressTo, subject, body);
                mail.IsBodyHtml = false; // Send as plain text, to avoid needing to escape special characters, etc.

                var smtp = new SmtpClient(SmtpHost, SmtpPort)
                {
                    EnableSsl = SmtpEnableSsl,
                    Credentials = new NetworkCredential(SmtpCredentialsUsername, SmtpCredentialsPassword)
                };
                smtp.Send(mail);

                // If still here, the feedback was sent successfully.
                return new FeedbackResponse()
                {
                    Status = "Thank you for your feedback!",
                    Message = "Your feedback has been sent successfully."
                };
            }
            catch (Exception)
            {
                // Could add some logging functionality here.  For a a more thorough discussion on error handling, 
                // see the "Try-catch" section in the accompanying walkthrough doc for this sample:
                // http://blogs.msdn.com/b/officeapps/archive/2013/06/05/create-a-web-service-for-an-app-for-office-using-the-asp-net-web-api.aspx

                return new FeedbackResponse()
                {
                    Status = "Sorry, your feedback could not be sent",
                    Message = "You may try emailing it directly to the support team."
                };
            }
        }
    }
}