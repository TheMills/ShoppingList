using System;
using System.Collections.Generic;

namespace ShoppingList.API.Models
{
    public class ShopList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ListItem> ListItems { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeModified { get; set; }
    }
}