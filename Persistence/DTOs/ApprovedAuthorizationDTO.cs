using System;
using System.Collections.Generic;

namespace Persistence.DTOs
{
    public partial class ApprovedAuthorizationDTO
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public decimal Amount { get; set; }
        public int ClientId { get; set; }

    }
}
