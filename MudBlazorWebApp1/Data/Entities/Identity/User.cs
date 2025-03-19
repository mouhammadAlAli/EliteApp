using Microsoft.AspNetCore.Identity;
using MudBlazorWebApp1.Data.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorWebApp1.Data.Entities.Identity;

public class User : IdentityUser<int>, IActiveEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DefaultValue(true)]
    public bool IsActive { get; set; } = true;
    public int? TeamId { get; set; }
    [ForeignKey(nameof(TeamId))]
    public Team Team { get; set; }
    public int? PracticeId { get; set; }
    [ForeignKey(nameof(PracticeId))]
    public Practice Practice { get; set; }
}
