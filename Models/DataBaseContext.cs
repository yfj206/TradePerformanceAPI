using Microsoft.EntityFrameworkCore;

namespace TradePerformanceAPI.Models
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
        {
            
        }
        public DbSet<Trader> Traders { get; set; } = null!;
    }
}
