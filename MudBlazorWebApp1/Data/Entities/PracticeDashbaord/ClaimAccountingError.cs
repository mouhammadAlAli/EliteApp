namespace MudBlazorWebApp1.Data.Entities.PracticeDashbaord
{
    public class ClaimAccountingError
    {
        public long ClaimId { get; set; }

        public Guid PracticeGuid { get; set; }

        public string ClaimtransactionTypeErrorName { get; set; }

        public string ClaimTransactionTypeCode { get; set; }
    }
}
