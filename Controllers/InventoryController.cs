using InventoryService.Data;
using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InventoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateItem(InventoryItem item)
        {
            _context.InventoryItems.Add(item);

            await _context.SaveChangesAsync();

            return Ok(item);
        }
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _context.InventoryItems
                .Where(x => x.IsActive)
                .ToListAsync();

            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var item = await _context.InventoryItems
                .FirstOrDefaultAsync(x => x.ItemId == id && x.IsActive);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, InventoryItem updatedItem)
        {
            var item = await _context.InventoryItems.FindAsync(id);

            if (item == null)
                return NotFound();

            item.ItemName = updatedItem.ItemName;
            item.Category = updatedItem.Category;
            item.Quantity = updatedItem.Quantity;
            item.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = await _context.InventoryItems.FindAsync(id);

            if (item == null)
                return NotFound();

            item.IsActive = false;
            item.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok("Item deleted successfully");
        }
    }
}