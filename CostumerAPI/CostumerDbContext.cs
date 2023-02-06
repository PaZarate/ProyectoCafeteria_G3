using CostumerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CostumerAPI
{
    public class CostumerDbContext : DbContext
    {
        public CostumerDbContext(DbContextOptions<CostumerDbContext> dbContextOptions) : base(dbContextOptions)
            {
               try
               {
                    var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                    if (databaseCreator != null)
                    {
                        if(!databaseCreator.CanConnect()) databaseCreator.Create();
                        if(!databaseCreator.HasTables()) databaseCreator.CreateTables();
                    }
               }
               catch(Exception ex)
               {
                    Console.WriteLine(ex.Message);
               }

            }
            
        public DbSet<Costumer> Costumers { get; set; }
    }
}
