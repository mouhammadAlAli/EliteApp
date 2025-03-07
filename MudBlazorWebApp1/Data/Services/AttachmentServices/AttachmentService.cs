using Microsoft.EntityFrameworkCore;
using MudBlazorWebApp1.Data.Entities;
using MudBlazorWebApp1.Data.Enums;

namespace MudBlazorWebApp1.Data.Services.AttachmentServices;

public class AttachmentService
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
    public async Task UpdateRefIdAsync(Attachment attachment, int refId)
    {
        if (attachment.RefId != null)
            throw new Exception("AttachmentAlreadyRelatedToEntity" +
                $"Id: {attachment.Id}, RefType: {attachment.RefType}");

        attachment.RefId = refId;
        _context.Update(attachment);
        await _context.SaveChangesAsync();
    }
    public async Task<Attachment> GetAndCheckAsync(int id, AttachmentRefType refType)
    {
        var attachment = await _context.Attachments.FirstOrDefaultAsync(x => x.Id == id);

        if (attachment?.RefType != refType)
            throw new Exception(("InvalidAttachmentRefType") +
                $"Id: {id}, RefType: {attachment.RefType} and should be {(byte)refType}");

        return attachment;
    }

    public async Task<Attachment> CheckAndUpdateRefIdAsync(int id, AttachmentRefType refType, int refId)
    {
        //Check if type is correct and update refId
        var attachment = await GetAndCheckAsync(id, refType);
        await UpdateRefIdAsync(attachment, refId);

        return attachment;
    }

    public async Task DeleteRefIdAsync(Attachment attachment)
    {
        attachment.RefId = null;
        _context.Update(attachment);
        await _context.SaveChangesAsync();
    }


    public void CheckAttachmentRefType(AttachmentRefType refType, AttachmentType fileType)
    {
        if (!AcceptedTypesFor(refType).Contains(fileType))
            throw new Exception(("FileTypeIncompatibleWithRefType") +
                $"Type:{fileType.ToString()}, RefType:{refType.ToString()}");
    }

    private static IEnumerable<AttachmentType> AcceptedTypesFor(AttachmentRefType refType)
    {
        switch (refType)
        {
            case AttachmentRefType.Profile:
                return ImagesAcceptedTypes;
        }

        return new AttachmentType[] { };
    }
}
