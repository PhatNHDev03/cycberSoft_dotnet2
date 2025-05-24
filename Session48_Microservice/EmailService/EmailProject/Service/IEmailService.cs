using EmailProject.DTOs;

namespace EmailProject.Service
{
    public interface IEmailservice
    {
        Task SendWellcomeEmailAsync(string email, string username);
    }

}