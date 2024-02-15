namespace AuthorizationService.Models
{
    public class ConfirmationRequest
    {
        public int Id { get; set; }
        public string AuthorizationRequestId { get; set; } 
        public DateTime ConfirmationDate { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
