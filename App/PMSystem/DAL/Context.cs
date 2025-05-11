using Microsoft.EntityFrameworkCore;
using Models;
namespace DAL
{

    public class Context : DbContext
    {
        public Context(string?ConnectionString):base() { 
            this.connectionString = ConnectionString;
        }


        public string? connectionString { get; private set; }

        public Context() : base() { }

        public DbSet<UserModel>Users { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<TaskModel>Tasks { get; set; }
        public DbSet<ProjectUser> InterConnector { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (this.connectionString is null)
            {
                this.connectionString = "Server=DESKTOP-I\\SARVAR; Database=PM_db Trusted_Connection=true; TrustServerCertificate=Yes";
            }

            optionsBuilder.UseSqlServer(this.connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            



            base.OnModelCreating(modelBuilder);
        }



    }

}
