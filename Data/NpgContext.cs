using Microsoft.EntityFrameworkCore;
using SmartCard_API.Models;

namespace SmartCard_API.Data
{
    public class NpgContext : DbContext
    {

        public DbSet<SmartCard> Smartcards { get; set; } = null!;

        public DbSet<ReceivedLog> ReceivedLogs { get; set; } = null!;

        public NpgContext(DbContextOptions<NpgContext> options)
          : base(options)
        {

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

    }
}
