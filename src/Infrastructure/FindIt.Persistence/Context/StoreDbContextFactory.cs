//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;

//namespace FindIt.Persistence.Context
//{
//    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
//    {
//        public StoreDbContext CreateDbContext(string[] args)
//        {
//            // Build configuration and point to the appsettings.json in the main project folder
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "D:\\FindIt\\src\\Presentation\\FindIt.Server\\FindIt.Server"))  // Adjust path to main project
//                .AddJsonFile("appsettings.json")
//                .Build();

//            var connectionString = configuration.GetConnectionString("FindItDb");

//            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
//            optionsBuilder.UseSqlServer(connectionString);

//            return new StoreDbContext(optionsBuilder.Options);
//        }
//    }
//}
