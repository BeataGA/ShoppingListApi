using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private static List<ShoppingList> ShoppingLists = new List<ShoppingList>();

        [HttpGet]
        public ActionResult<IEnumerable<ShoppingList>> GetAll()
        {
            return Ok(ShoppingLists);
        }

        [HttpPost]
        public ActionResult Add([FromBody] ShoppingList shoppingList)
        {
            var existingList = ShoppingLists.FirstOrDefault(s => s.Name == shoppingList.Name);

            if (existingList != null)
            {
                existingList.Products = shoppingList.Products;
                return Ok(existingList);
            }

            shoppingList.Id = ShoppingLists.Count + 1;
            ShoppingLists.Add(shoppingList);
            return CreatedAtAction(nameof(GetAll), shoppingList);
        }

    }
}
