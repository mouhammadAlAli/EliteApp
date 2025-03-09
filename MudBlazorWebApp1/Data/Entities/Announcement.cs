using MudBlazorWebApp1.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorWebApp1.Data.Entities;

public class Announcement : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int? TeamId { get; set; }
    [ForeignKey(nameof(TeamId))]
    public Team Team { get; set; }
}
