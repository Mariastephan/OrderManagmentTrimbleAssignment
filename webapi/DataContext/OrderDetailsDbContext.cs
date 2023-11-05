using Microsoft.EntityFrameworkCore;
using orderManagement.webApi.Model;

namespace orderManagement.webApi.DataContext
{
    public class OrderDetailsDbContext: DbContext
    {
        public OrderDetailsDbContext(DbContextOptions<OrderDetailsDbContext> options) : base(options) { 
        

        }

        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
