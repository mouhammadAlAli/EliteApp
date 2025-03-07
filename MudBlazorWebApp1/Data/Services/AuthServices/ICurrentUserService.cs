using MudBlazorWebApp1.Data.Entities.Identity;

namespace MudBlazorWebApp1.Data.Services.AuthServices
{
    public interface ICurrentUserService
    {
        Task<User> GetCurrentUserAsync();
        Task<int> GetCurrentUserIdAsync();
    }
}