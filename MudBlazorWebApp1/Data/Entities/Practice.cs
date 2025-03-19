using MudBlazorWebApp1.Data.Entities.Base;
using MudBlazorWebApp1.Data.Entities.Identity;

namespace MudBlazorWebApp1.Data.Entities;

public class Practice : BaseEntity
{
    public Practice()
    {
        Doctors = new HashSet<User>();
    }
    public Guid? Guid { get; set; }
    public string Name { get; set; }
    public ICollection<User> Doctors { get; set; }
}
