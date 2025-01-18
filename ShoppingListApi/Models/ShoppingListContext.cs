using Microsoft.EntityFrameworkCore;

namespace ShoppingListApi.Models
{
    public class ShoppingListContext : DbContext
    {
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }

        public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship using a shadow property for ShoppingListId
            modelBuilder.Entity<ListItem>()
                .HasOne(i => i.ShoppingList)
                .WithMany(s => s.Items)
                .HasForeignKey("ShoppingListId");  // Shadow property for the foreign key
        }
    }
}
