using Microsoft.EntityFrameworkCore;
using Models;
namespace DAL
{

    public class Context : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I\\SARVAR; Database=PMSystem_db; Trusted_Connection=true; TrustServerCertificate=Yes");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUser>()

            .HasKey(pu => new { pu.ProjectId, pu.UserId });

            modelBuilder.Entity<ProjectUser>()

                .HasOne(pu => pu.Project)

                .WithMany(p => p.ProjectUsers)

                .HasForeignKey(pu => pu.ProjectId);

            modelBuilder.Entity<ProjectUser>()

                .HasOne(pu => pu.User)

                .WithMany(u => u.ProjectUsers)

                .HasForeignKey(pu => pu.UserId);

            modelBuilder.Entity<TaskModel>()

                .HasOne(t => t.User)

                .WithMany(u => u.Tasks)

                .HasForeignKey(t => t.UserId)

                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskModel>()

                .HasOne(t => t.Project)

                .WithMany(p => p.Tasks)

                .HasForeignKey(t => t.ProjectId)

                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
