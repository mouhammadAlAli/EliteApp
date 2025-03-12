using Microsoft.AspNetCore.Components.Forms;
using MudBlazorWebApp1.Data.Entities;
using MudBlazorWebApp1.Data.Enums;

namespace MudBlazorWebApp1.Data.Services.AttachmentServices;

public interface IAttachmentService
{
    Task<Attachment> GetAttachmentByRefIdAndRefTypeAsync(int refId, AttachmentRefType refType);
    Task<Attachment> CheckAndUpdateRefIdAsync(int id, AttachmentRefType refType, int refId);
    Task<Attachment> GetAndCheckAsync(int id, AttachmentRefType refType);
    Task RemoveRefIdAsync(int id);
    Task UpdateRefIdAsync(Attachment attachment, int refId);
    Task DeleteByRefTypeAndRefId(AttachmentRefType refType, int refId);
    Task<Attachment> UploadFileAsync(IBrowserFile file, AttachmentRefType refType, int? refId = null);
    void ValidateAttachmentType(AttachmentRefType refType, AttachmentType fileType);
    string GetImageUrl(Attachment attachment);
}