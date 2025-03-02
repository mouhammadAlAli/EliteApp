using Microsoft.AspNetCore.Identity;
using MudBlazorWebApp1.Data.Entities.Base;
using System.ComponentModel;

namespace MudBlazorWebApp1.Data.Entities.Identity;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser<int>, IActiveEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DefaultValue(true)]
    public bool IsActive { get; set; } = true;
}
