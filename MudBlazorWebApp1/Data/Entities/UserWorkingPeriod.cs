using MudBlazorWebApp1.Data.Entities.Base;
using MudBlazorWebApp1.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorWebApp1.Data.Entities;

public class UserWorkingPeriod : BaseEntity
{
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public DateTime Date { get; set; }
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
    public bool IsFromEntry { get; set; }

}
