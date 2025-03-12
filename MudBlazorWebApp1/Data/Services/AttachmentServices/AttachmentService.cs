using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using MudBlazorWebApp1.Data.Entities;
using MudBlazorWebApp1.Data.Enums;

namespace MudBlazorWebApp1.Data.Services.AttachmentServices;

public class AttachmentService : IAttachmentService
{
    private readonly ApplicationDbContext _context;

    public AttachmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    private static readonly AttachmentType[] AllAcceptedTypes =
        { AttachmentType.JPEG, AttachmentType.JPG, AttachmentType.PDF, AttachmentType.PNG, AttachmentType.WORD };

    private static readonly AttachmentType[] ImagesAcceptedTypes =
        { AttachmentType.JPEG, AttachmentType.JPG, AttachmentType.PNG };

    public async Task<Attachment> UploadFileAsync(IBrowserFile file, AttachmentRefType refType, int? refId = null)
    {
        if (file == null || file.Size == 0)
            throw new ArgumentException("Invalid file.");

        var fileType = GetAttachmentType(file.ContentType);
        ValidateAttachmentType(refType, fileType);

        var fileContent = new byte[file.Size];
        using var stream = file.OpenReadStream();
        await stream.ReadAsync(fileContent, 0, (int)file.Size);

        var attachment = new Attachment
        {
            Name = file.Name,
            Type = fileType,
            RefId = refId,
            RefType = refType,
            FileContent = fileContent
        };

        _context.Attachments.Add(attachment);
        await _context.SaveChangesAsync();

        return attachment;
    }

    private static AttachmentType GetAttachmentType(string contentType)
    {
        return contentType switch
        {
            "image/jpeg" => AttachmentType.JPEG,
            "image/png" => AttachmentType.PNG,
            "image/jpg" => AttachmentType.JPG,
            "application/pdf" => AttachmentType.PDF,
            "application/msword" => AttachmentType.WORD,
            "video/mp4" => AttachmentType.MP4,
            "audio/mpeg" => AttachmentType.MP3,
            "application/octet-stream" => AttachmentType.APPLICATION,
            _ => throw new NotSupportedException($"Unsupported file type: {contentType}")
        };
    }

    public async Task UpdateRefIdAsync(Attachment attachment, int refId)
    {
        if (attachment.RefId != null)
            throw new InvalidOperationException($"Attachment is already related to an entity. Id: {attachment.Id}, RefType: {attachment.RefType}");

        attachment.RefId = refId;
        _context.Attachments.Update(attachment);
        await _context.SaveChangesAsync();
    }

    public async Task<Attachment> GetAndCheckAsync(int id, AttachmentRefType refType)
    {
        var attachment = await _context.Attachments.FirstOrDefaultAsync(x => x.Id == id);

        if (attachment == null)
            throw new KeyNotFoundException($"Attachment with ID {id} not found.");

        if (attachment.RefType != refType)
            throw new InvalidOperationException($"Invalid Attachment RefType. Id: {id}, Found RefType: {attachment.RefType}, Expected: {(byte)refType}");

        return attachment;
    }

    public async Task<Attachment> CheckAndUpdateRefIdAsync(int id, AttachmentRefType refType, int refId)
    {
        var attachment = await GetAndCheckAsync(id, refType);
        await UpdateRefIdAsync(attachment, refId);

        return attachment;
    }

    public async Task RemoveRefIdAsync(int id)
    {
        var attachment = await _context.Attachments.FindAsync(id);
        if (attachment == null)
            throw new KeyNotFoundException($"Attachment with ID {id} not found.");

        attachment.RefId = null;
        _context.Attachments.Update(attachment);
        await _context.SaveChangesAsync();
    }

    public void ValidateAttachmentType(AttachmentRefType refType, AttachmentType fileType)
    {
        if (!AcceptedTypesFor(refType).Contains(fileType))
            throw new NotSupportedException($"File type {fileType} is incompatible with RefType {refType}");
    }

    private static IEnumerable<AttachmentType> AcceptedTypesFor(AttachmentRefType refType)
    {
        return refType switch
        {
            AttachmentRefType.Profile => ImagesAcceptedTypes,
            _ => []
        };
    }

    public async Task DeleteByRefTypeAndRefId(AttachmentRefType refType, int refId)
    {
        var attachments = await _context.Attachments.Where(x => x.RefId == refId && x.RefType == refType).ToListAsync();
        if (attachments != null && attachments.Any())
        {
            _context.RemoveRange(attachments);
        }
    }

    public async Task<Attachment> GetAttachmentByRefIdAndRefTypeAsync(int refId, AttachmentRefType refType)
    {
        var result = await _context.Attachments.Where(x => x.RefId == refId && x.RefType == refType).FirstOrDefaultAsync();
        return result;
    }

    public string GetImageUrl(Attachment attachment)
    {
        if (attachment == null) return "";
        return $"data:image/{attachment.Type};base64,{Convert.ToBase64String(attachment.FileContent)}";
    }
}
