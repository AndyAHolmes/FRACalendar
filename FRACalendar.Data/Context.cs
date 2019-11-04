using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore.Relational;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;

namespace FRACalendar.Data
{
    public class FRACalendarContext : DbContext {
        public FRACalendarContext(DbContextOptions<FRACalendarContext> options):base(options)
        //public FRACalendarContext():base()
        {
            /*
            To use migrations 
            set the project to the same as the data context.
            install-package Microsoft.EntityFrameworkCore.Tools 

            I couldn't get dotnet ef to work, inspite of doing dotnet install -g dotnet-ef 
            instead the EF Core tools make add-migration and update-database available from the package manager console.  At this point classic ef commands can be used to create migrations.

            Add-Migration InitialMigration -p FRACalendar.Data -s FRACalendar
            update-database -p FRACalendar.Data -s FRACalendar

                If the model has changed and no migration then an error is thrown about invalid columns.
                Same error if there is a migration and it hasn't been applied.

            Not sure how this will work for actual deployment.  
            Also, migrations are not auto applied.  I haven't tried accessing the db without all migration having been applied yet.  Don't know if this results in similar exceptions to EF6.
            
            try with string what i did with bool.  I suspect the same will happen.  
            Wonder if the just reversin from db will work without the need for migrations with ef core.
            Wonder if the just reversin from db will work without the need for migrations with ef core.
             
             */
        }

        public DbSet<Race> Races { get; set; }
        public DbSet<RaceContact> RaceContacts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Race>().ToTable("Race");
            builder.Entity<RaceContact>().ToTable("RaceContact");
            
            
        }

        public static void CreateDbIfNotExists(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<FRACalendarContext>();
                    Seed(context);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void Seed(FRACalendarContext context)
        {
            if (context.Races.Any()) return;
            context.Races.Add(new Race { Name = "Gravy Pud", Price = 5.0M, RaceClimbInFeet = 800, RaceDate = new DateTime(2019, 08, 12), RaceDistanceInMiles = 3, StartTime = new DateTime(2019, 08, 12, 11, 0, 0), FRAInsured=false });
            context.Races.Add(new Race { Name = "Peris Horseshoe", Price = 18.0M, RaceClimbInFeet = 7000, RaceDate = new DateTime(2019, 06, 12), RaceDistanceInMiles = 18, StartTime = new DateTime(2019, 06, 12, 11, 0, 0), FRAInsured = false });
            context.SaveChanges();
        }

    }

}
