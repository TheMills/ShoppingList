using Microsoft.EntityFrameworkCore;
using ShoppingList.API.Models;

namespace ShoppingList.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) {}
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<ShopList> ShoppingLists { get; set; }
    }
}