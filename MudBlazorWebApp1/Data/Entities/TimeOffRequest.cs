using MudBlazorWebApp1.Data.Entities.Base;
using MudBlazorWebApp1.Data.Entities.Identity;
using MudBlazorWebApp1.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorWebApp1.Data.Entities;

public class TimeOffRequest : BaseEntity
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public int Hours { get; set; }
    public string Note { get; set; }
    public RequestTimeOffStatus Status { get; set; }
    public TimeOffCategory TimeOffCategory { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
}
