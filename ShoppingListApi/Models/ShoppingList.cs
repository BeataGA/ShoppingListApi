using System.Collections.Generic;

namespace ShoppingListApi.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Products { get; set; } = new List<string>();
    }
}

