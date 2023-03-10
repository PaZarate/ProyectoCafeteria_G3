using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductAPI.Models;

namespace ProductAPI
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } 
        public ProductDbContext(DbContextOptions <ProductDbContext>dbContextOptions) : base (dbContextOptions)
        {

            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreator != null)
                {
                    //Creacion de la BD (Excepciones)
                    if(!databaseCreator.CanConnect()) databaseCreator.Create();

                    //Creacion de las tablas en caso no existiera
                    if(!databaseCreator.HasTables()) databaseCreator.CreateTables();


                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                    
        }



    }
}
