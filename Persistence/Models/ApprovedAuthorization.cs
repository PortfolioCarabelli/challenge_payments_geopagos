using System;
using System.Collections.Generic;

namespace Persistence.Models
{
    public partial class ApprovedAuthorization
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public decimal Amount { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual AuthorizationRequest Request { get; set; } = null!;
    }
}
