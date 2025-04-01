using System.ComponentModel.DataAnnotations;

namespace MudBlazorWebApp1.Data.Entities.PracticeDashbaord
{
    public class PaymentClaims
    {
        public Guid EncounterGuid { get; set; }

        public long PaymentId { get; set; }

        public long ClaimId { get; set; }
    }
}
