using session40_50.Interfaces;
using session40_50.Models;
using session40_52.Data;

namespace session40_50.Repsitory
{
    public class AuthRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User?> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
