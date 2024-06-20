using fruitable.Data;
using Fruitable.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Fruitable.Utilities
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public ConfigurationHelper(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,ApplicationDbContext context)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public string GetConnectionString(string name)
        {
            return _configuration.GetConnectionString(name)!;
        }

        public T GetSection<T>(string sectionName) where T : new()
        {
            var section = new T();
            _configuration.GetSection(sectionName).Bind(section);
            return section;
        }

        public async Task<ApplicationUser> GetCurrentUserDetailsAsync()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                var user = await _context.Users.FindAsync(userId);
                return user;
            }

            return null;
        }
    }
}
