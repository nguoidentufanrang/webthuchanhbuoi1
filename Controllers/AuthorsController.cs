﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webthuchanhbuoi1.Data;
using webthuchanhbuoi1.Models;

namespace webthuchanhbuoi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authors>>> GetAuthor()
        {
            return await _context.Author.ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Authors>> GetAuthors(int? id)
        {
            var authors = await _context.Author.FindAsync(id);

            if (authors == null)
            {
                return NotFound();
            }

            return authors;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthors(int? id, Authors authors)
        {
            if (id != authors.Id)
            {
                return BadRequest();
            }

            _context.Entry(authors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorsExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Authors>> PostAuthors(Authors authors)
        {
            _context.Author.Add(authors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthors", new { id = authors.Id }, authors);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthors(int? id)
        {
            var authors = await _context.Author.FindAsync(id);
            if (authors == null)
            {
                return NotFound();
            }

            _context.Author.Remove(authors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorsExists(int? id)
        {
            return _context.Author.Any(e => e.Id == id);
        }
    }
}
