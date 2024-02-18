using System;
using System.Collections.Generic;

namespace Persistence.Models
{
    public partial class Client
    {
        public Client()
        {
            ApprovedAuthorizations = new HashSet<ApprovedAuthorization>();
            AuthorizationRequests = new HashSet<AuthorizationRequest>();
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ClientType { get; set; } = null!;

        public virtual ICollection<ApprovedAuthorization> ApprovedAuthorizations { get; set; }
        public virtual ICollection<AuthorizationRequest> AuthorizationRequests { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
