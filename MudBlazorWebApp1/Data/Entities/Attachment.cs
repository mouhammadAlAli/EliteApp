using MudBlazorWebApp1.Data.Entities.Base;
using MudBlazorWebApp1.Data.Enums;

namespace MudBlazorWebApp1.Data.Entities;

public class Attachment : BaseEntity
{
    public string Name { get; set; }
    public AttachmentType Type { get; set; }
    public int? RefId { get; set; }
    public AttachmentRefType RefType { get; set; }

    public byte[] FileContent { get; set; }

    public static bool IsValidAttachmentRefType(byte type)
    {
        return Enum.IsDefined(typeof(AttachmentRefType), type);
    }
}
