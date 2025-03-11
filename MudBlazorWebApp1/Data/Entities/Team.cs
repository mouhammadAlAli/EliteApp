using MudBlazorWebApp1.Data.Entities.Base;
using MudBlazorWebApp1.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorWebApp1.Data.Entities;

public class Team : BaseEntity
{
    public Team()
    {
        Members = new HashSet<User>();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LeaderId { get; set; }
    [ForeignKey(nameof(LeaderId))]
    public virtual User Leader { get; set; }
    public ICollection<User> Members { get; set; }
}
