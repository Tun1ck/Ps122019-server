using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ps122019_server.Contexts;
using Ps122019_server.Models;

namespace Ps122019_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsListsController : ControllerBase
    {
        private readonly ItemsListContext _context;

        public ItemsListsController(ItemsListContext context)
        {
            _context = context;
        }

        // GET: api/ItemsLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemsList>>> GetItemsList()
        {
            return await _context.ItemsList.ToListAsync();
        }

        // GET: api/ItemsLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemsList>> GetItemsList(int id)
        {
            var itemsList = await _context.ItemsList.FindAsync(id);

            if (itemsList == null)
            {
                return NotFound();
            }

            return itemsList;
        }

        // PUT: api/ItemsLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemsList(int id, ItemsList itemsList)
        {
            if (id != itemsList.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemsList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemsListExists(id))
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

        // POST: api/ItemsLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItemsList>> PostItemsList(ItemsList itemsList)
        {
            _context.ItemsList.Add(itemsList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemsList", new { id = itemsList.Id }, itemsList);
        }

        // DELETE: api/ItemsLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemsList>> DeleteItemsList(int id)
        {
            var itemsList = await _context.ItemsList.FindAsync(id);
            if (itemsList == null)
            {
                return NotFound();
            }

            _context.ItemsList.Remove(itemsList);
            await _context.SaveChangesAsync();

            return itemsList;
        }

        private bool ItemsListExists(int id)
        {
            return _context.ItemsList.Any(e => e.Id == id);
        }
    }
}
