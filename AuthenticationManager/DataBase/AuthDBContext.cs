using AuthenticationManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AuthenticationManager.DataBase
{
    public class AuthDBContext:DbContext
    {


        public AuthDBContext(DbContextOptions<AuthDBContext> dbContextOptions):base(dbContextOptions) 
        {


            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect())
                    {
                        databaseCreator.Create();
                    }
                    if (!databaseCreator.HasTables())
                    {
                        databaseCreator.CreateTables();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }
       public DbSet<UserAccount> Accounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(

               new UserAccount
               {
                   UserName="shailesh@gmail.com",
                   Password="12345",
                   Role="admin"
               },
               new UserAccount
               {
                   UserName="oleksii@gmail.com",
                   Password= "12345",
                   Role="admin"

               },
               new UserAccount
               {
                   UserName="randika@gmai.com",
                   Password="12345",
                   Role = "admin"
               }



                );
        }

    }
}
