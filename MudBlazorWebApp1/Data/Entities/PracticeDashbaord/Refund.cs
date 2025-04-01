namespace MudBlazorWebApp1.Data.Entities.PracticeDashbaord
{
    public class Refund
    {
        public DateTime PostingDate { get; set; }

        public Guid PracticeGuid { get; set; }  // VARCHAR(36)

        public decimal RefundAmount { get; set; }
    }
}
