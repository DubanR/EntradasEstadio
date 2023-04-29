using EntradasEstadio.Shared.Entities;
using EntradasEstadio.Shared.Enums;
using EntradasEstadio.API.Data;

namespace Subastongo.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTicketsAsync();        
        }

        private async Task CheckTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {
                for (int i = 1; i <= 50000; i++)
                {
                    await AddTicketsAsync(false);
                }

                await _context.SaveChangesAsync();
            }
        }

        private async Task AddTicketsAsync(bool used)
        {
            Ticket ticket = new()
            {
                Used  = used,
            };

            _context.Tickets.Add(ticket);
        }

    }
}