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

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.UserEmail).IsRequired().HasMaxLength(150);
                entity.Property(u => u.UserPassword).IsRequired();
                entity.Property(u => u.UserRole).HasMaxLength(50);

                entity.HasMany(u => u.Tasks)
                      .WithOne(t => t.User)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProjectModel>(entity =>
            {
                entity.HasKey(p => p.ProjectId);
                entity.Property(p => p.ProjectName).IsRequired().HasMaxLength(200);
                entity.Property(p => p.ProjectMethodology).HasMaxLength(100);

                entity.HasMany(p => p.Tasks)
                      .WithOne(t => t.Project)
                      .HasForeignKey(t => t.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<ProjectUser>(entity =>
            {
                entity.HasKey(pu => new { pu.ProjectId, pu.UserId });

                entity.HasOne(pu => pu.Project)
                      .WithMany(p => p.Users)
                      .HasForeignKey(pu => pu.ProjectId);

                entity.HasOne(pu => pu.User)
                      .WithMany(u => u.ProjectUsers)
                      .HasForeignKey(pu => pu.UserId);
            });


            modelBuilder.Entity<TaskModel>(entity =>
            {
                entity.HasKey(t => t.TaskId);
                entity.Property(t => t.TaskName).IsRequired().HasMaxLength(200);
                entity.Property(t => t.TaskStatus).HasMaxLength(50);
                entity.Property(t => t.TaskDescription);
                entity.Property(t => t.Notes);
            });

            base.OnModelCreating(modelBuilder);
        }



    }

}
