using System;
using System.Collections.Generic;

namespace Persistence.DTOs
{
    public partial class ClientDTO
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ClientType { get; set; } = null!;

    }
}
