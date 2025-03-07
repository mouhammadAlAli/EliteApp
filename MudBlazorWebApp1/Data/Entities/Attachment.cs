using MudBlazorWebApp1.Data.Entities.Base;
using MudBlazorWebApp1.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MudBlazorWebApp1.Data.Entities;

public class Attachment : BaseEntity
{
    public string Name { get; set; }

    public AttachmentType Type { get; set; }

    /// <summary>
    /// Path of the attachment file relative to configured dir
    /// </summary>
    [Required]
    [StringLength(1000)]
    public string RelativePath { get; set; }
    public int? RefId { get; set; }

    public AttachmentRefType RefType { get; set; }
    public static bool IsValidAttachmentRefType(byte type)
    {
        return Enum.IsDefined(typeof(AttachmentRefType), type);
    }
}
