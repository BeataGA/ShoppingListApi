using System.Collections.Generic;

namespace ShoppingListApi.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ListItem> Items { get; set; } = new List<ListItem>();
    }
}

