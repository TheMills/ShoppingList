namespace ShoppingList.API.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ActiveOnList { get; set; }
    }
}