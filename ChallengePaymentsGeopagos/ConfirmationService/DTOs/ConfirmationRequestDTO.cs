namespace AuthorizationService.DTOs
{
    public class ConfirmationRequestDTO
    {
        public string AuthorizationRequestId { get; set; }
        public DateTime ConfirmationDate { get; set; }
    }
}
