using Fruitable.Data.Models;

namespace Fruitable.Repositry.Email
{
    public interface IEmailRepositry
    {
        Task SendEmailConfirmationAsync(ApplicationUser user, string otp);
    }
}
