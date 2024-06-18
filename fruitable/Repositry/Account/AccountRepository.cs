namespace Fruitable.Repositry.Account
{
    public class AccountRepository : IAccountRepository
    {
        public int GenerateOTP()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp;
        }
    }
}
