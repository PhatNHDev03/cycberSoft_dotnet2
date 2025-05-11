using Microsoft.EntityFrameworkCore;
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

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User?> GetUserByVerificationTokenAsync(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);
            if (user == null) return null;
            user.IsEmailVerified = true;
            user.VerificationToken = null;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var local = _context.Users.Local.FirstOrDefault(e => e.Id == user.Id);
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User?> GetUserResetToken(string token)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.ResetPasswordToken == token);
            if (user == null) return null;
            if (DateTime.Now > user.ExpiresTokenResetPassword) return null;
            return user;
        }
    }
}
