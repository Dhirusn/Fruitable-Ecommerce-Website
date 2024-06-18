namespace Fruitable.Repositry.JWT
{
    public interface IJwtTokenRepository
    {
        Task<string> GenerateTokenAsync(string username, IEnumerable<string> roles);
    }
}
