﻿using EntradasEstadio.API.Data;
using EntradasEstadio.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntradasEstadio.API.Controllers
{
    [ApiController]
    [Route("/api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFull()
        {
            try
            {
                return Ok(await _context.Tickets
                    .ToListAsync());
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
                if (ticket == null)
                {
                    return NotFound();
                }
                return Ok(ticket);
            }

            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Ticket ticket)
        {
            try
            {
                _context.Update(ticket);
                await _context.SaveChangesAsync();
                return Ok(ticket);
            }

            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}

