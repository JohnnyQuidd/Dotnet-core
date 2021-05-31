using FirstApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApplication.data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        {
            
        }
        
        public DbSet<Command> Commands { get; set; }
    }
}