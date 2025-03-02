using Microsoft.AspNetCore.Identity;
using MudBlazorWebApp1.Data.Entities.Base;
using System.ComponentModel;

namespace MudBlazorWebApp1.Data.Entities.Identity;

public class Role : IdentityRole<int>, IActiveEntity
{
    public ICollection<IdentityRoleClaim<int>> IdentityRoleClaim { get; set; }
    [DefaultValue(true)]
    public bool IsActive { get; set; } = true;
    public Role()
       : base()
    {
    }

    public Role(string roleName) : base(roleName)
    {
    }

}
