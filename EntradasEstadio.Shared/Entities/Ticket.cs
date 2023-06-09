﻿using EntradasEstadio.Shared.Enums;

namespace EntradasEstadio.Shared.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public DateTime? UseDate { get; set; } = null;

        public bool Used { get; set; }

        public AccessGate? Access { get; set; } = null;
    }
}
