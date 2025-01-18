using System.Collections.Generic;
using Newtonsoft.Json; 
namespace ShoppingListApi.Models

{
    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Name of the product/item
    
        [JsonIgnore]
        public ShoppingList? ShoppingList { get; set; }  // Navigation property to ShoppingLists
    }
}

