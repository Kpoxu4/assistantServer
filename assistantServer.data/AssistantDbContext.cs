using assistantServer.data.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace assistantServer.data
{
    public class AssistantDbContext : DbContext {
       
        public DbSet<User> Users { get; set; }

        public AssistantDbContext() { }
        public AssistantDbContext(DbContextOptions<AssistantDbContext> contextOptions) : base(contextOptions) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("AssistantDbContext");              
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
