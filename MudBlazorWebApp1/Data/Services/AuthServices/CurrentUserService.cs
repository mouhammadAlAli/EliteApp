using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazorWebApp1.Data.Entities.Identity;

namespace MudBlazorWebApp1.Data.Services.AuthServices;

public class CurrentUserService : ICurrentUserService
{
    private readonly UserManager<User> _userManager;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public CurrentUserService(UserManager<User> userManager, AuthenticationStateProvider authenticationStateProvider)
    {
        _userManager = userManager;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<User> GetCurrentUserAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            return await _userManager.GetUserAsync(user);
        }

        return null;
    }

    public async Task<int> GetCurrentUserIdAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            // Get the User object from ClaimsPrincipal
            var appUser = await _userManager.GetUserAsync(user);

            if (appUser != null)
            {
                // Return the UserId (assuming it is an int)
                return appUser.Id;
            }
        }

        return 0;
    }
}
