using Microsoft.AspNetCore.Identity.UI.Services;

namespace Library_Web.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;   //Sizler buraya email gönderme işlemlerinizi yapabilirsiniz/ekleyebilirsiniz.
        }
    }
}
