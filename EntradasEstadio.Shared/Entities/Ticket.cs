using EntradasEstadio.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace EntradasEstadio.Shared.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public DateTime UseDate { get; set; }

        public bool Used { get; set; }

        public AccessGate Access { get; set; }
    }
}
