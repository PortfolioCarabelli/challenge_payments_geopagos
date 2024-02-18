using System;
using System.Collections.Generic;

namespace Persistence.Models
{
    public partial class AuthorizationRequest
    {
        public AuthorizationRequest()
        {
            ApprovedAuthorizations = new HashSet<ApprovedAuthorization>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string AuthorizationType { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? RequestDate { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<ApprovedAuthorization> ApprovedAuthorizations { get; set; }
    }
}
