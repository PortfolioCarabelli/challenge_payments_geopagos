namespace AuthorizationService.Models
{
    public class AuthorizationRequest
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
    }
}
