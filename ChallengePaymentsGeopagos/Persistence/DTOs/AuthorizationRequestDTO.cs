using System;
using System.Collections.Generic;

namespace Persistence.DTOs
{
    public partial class AuthorizationRequestDTO
    {

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string AuthorizationType { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? RequestDate { get; set; }


    }
}
