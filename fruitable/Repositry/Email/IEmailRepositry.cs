using Fruitable.Models;

namespace Fruitable.Repositry.Email
{
    public interface IEmailRepositry
    {
        Task SendEmailConfirmationAsync(ApplicationUser user, string otp);
    }
}
