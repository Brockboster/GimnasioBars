﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GimnasioBars.Models;
using GimnasioBars.Attributes;

namespace GimnasioBars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class UserStatusController : ControllerBase
    {
        private readonly Gimnasio_BarsContext _context;

        public UserStatusController(Gimnasio_BarsContext context)
        {
            _context = context;
        }

        // GET: api/UserStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStatus>>> GetUserStatuses()
        {
          if (_context.UserStatuses == null)
          {
              return NotFound();
          }
            return await _context.UserStatuses.ToListAsync();
        }

        // GET: api/UserStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStatus>> GetUserStatus(int id)
        {
          if (_context.UserStatuses == null)
          {
              return NotFound();
          }
            var userStatus = await _context.UserStatuses.FindAsync(id);

            if (userStatus == null)
            {
                return NotFound();
            }

            return userStatus;
        }

        // PUT: api/UserStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStatus(int id, UserStatus userStatus)
        {
            if (id != userStatus.IdStatus)
            {
                return BadRequest();
            }

            _context.Entry(userStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserStatus>> PostUserStatus(UserStatus userStatus)
        {
          if (_context.UserStatuses == null)
          {
              return Problem("Entity set 'Gimnasio_BarsContext.UserStatuses'  is null.");
          }
            _context.UserStatuses.Add(userStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserStatusExists(userStatus.IdStatus))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserStatus", new { id = userStatus.IdStatus }, userStatus);
        }

        // DELETE: api/UserStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStatus(int id)
        {
            if (_context.UserStatuses == null)
            {
                return NotFound();
            }
            var userStatus = await _context.UserStatuses.FindAsync(id);
            if (userStatus == null)
            {
                return NotFound();
            }

            _context.UserStatuses.Remove(userStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserStatusExists(int id)
        {
            return (_context.UserStatuses?.Any(e => e.IdStatus == id)).GetValueOrDefault();
        }
    }
}
