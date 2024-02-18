using System;
using System.Collections.Generic;

namespace Persistence.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
