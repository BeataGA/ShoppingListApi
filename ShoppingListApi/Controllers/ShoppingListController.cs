using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly ShoppingListContext _context;

        public ShoppingListController(ShoppingListContext context)
        {
            _context = context;
        }

        // Get all shopping lists along with their items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingList>>> GetAll()
        {
            var shoppingLists = await _context.ShoppingLists
                .Include(s => s.Items)  // Include ListItems when retrieving ShoppingLists
                .ToListAsync();
            return Ok(shoppingLists);
        }

        // Add a new shopping list with items
[HttpPost]
public async Task<ActionResult<ShoppingList>> AddOrUpdate([FromBody] ShoppingList shoppingList)
{
    // Check if the shopping list already exists in the database
    var existingList = await _context.ShoppingLists
                                      .Include(s => s.Items)  // Ensure we load related items
                                      .FirstOrDefaultAsync(s => s.Id == shoppingList.Id);

    if (existingList != null)
    {
        // Update the existing shopping list
        existingList.Name = shoppingList.Name;

        // Remove items that are no longer in the payload
        var itemsToRemove = existingList.Items
            .Where(existingItem => !shoppingList.Items
                .Any(newItem => newItem.Id == existingItem.Id)).ToList();
        
        // Remove items from the shopping list
        _context.ListItems.RemoveRange(itemsToRemove);  // Now using ListItem DbSet

        // Add new items or update existing items
        foreach (var item in shoppingList.Items)
        {
            var existingItem = existingList.Items.FirstOrDefault(i => i.Id == item.Id);

            if (existingItem != null)
            {
                // Update existing item
                existingItem.Name = item.Name;
            }
            else
            {
                // Add new item
                existingList.Items.Add(item);
            }
        }

        _context.ShoppingLists.Update(existingList);
    }
    else
    {
        // If the shopping list doesn't exist, create a new one
        _context.ShoppingLists.Add(shoppingList);
    }

    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetAll), new { id = shoppingList.Id }, shoppingList);
}



    }
}
