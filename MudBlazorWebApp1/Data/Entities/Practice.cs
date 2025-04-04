using MudBlazorWebApp1.Data.Entities.Base;

namespace MudBlazorWebApp1.Data.Entities;

public class Practice : BaseEntity
{
    public Guid? Guid { get; set; }
    public string Name { get; set; }
}
