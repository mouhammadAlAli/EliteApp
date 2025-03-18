namespace MudBlazorWebApp1.Data.Enums;

public enum AttachmentType : byte
{
    PDF = 1,
    WORD = 2,
    JPEG = 3,
    PNG = 4,
    JPG = 5,
    MP4 = 6,
    MP3 = 7,
    APPLICATION = 8,
}
public static class AttachmentTypeExtensions
{
    public static (string MimeType, string Extension) GetMimeTypeAndExtension(this AttachmentType type)
    {
        return type switch
        {
            AttachmentType.PDF => ("application/pdf", "pdf"),
            AttachmentType.WORD => ("application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx"),
            AttachmentType.JPEG => ("image/jpeg", "jpeg"),
            AttachmentType.PNG => ("image/png", "png"),
            AttachmentType.JPG => ("image/jpeg", "jpg"),
            AttachmentType.MP4 => ("video/mp4", "mp4"),
            AttachmentType.MP3 => ("audio/mpeg", "mp3"),
            AttachmentType.APPLICATION => ("application/octet-stream", "bin"),
            _ => ("application/octet-stream", "bin")
        };
    }
}