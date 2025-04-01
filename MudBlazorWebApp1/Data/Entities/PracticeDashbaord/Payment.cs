namespace MudBlazorWebApp1.Data.Entities.PracticeDashbaord
{
    public class Payment
    {
        public long PaymentId { get; set; }

        public DateTime PostingDate { get; set; }

        public Guid PracticeGuid { get; set; }  // VARCHAR(36)

        public Guid? SourceEncounterGuid { get; set; }

        public decimal PaymentAmount { get; set; }
    }
}
