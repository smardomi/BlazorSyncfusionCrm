using BlazorSyncfusionCrm.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCrm.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base()
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlazorSyncfusionCrmDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    FirstName = "Saeed",
                    LastName = "Mardomi",
                    NickName = "Fasterrr",
                    Place = "Tabriz",
                    DateOfBirth = new DateTime(1995, 3, 9)
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Vahid",
                    LastName = "Mardomi",
                    NickName = "Vh",
                    Place = "Tabriz",
                    DateOfBirth = new DateTime(1999, 9, 15)
                },
                new Contact
                {
                    Id = 3,
                    FirstName = "Fereshteh",
                    LastName = "Sadeghi",
                    NickName = "FS",
                    Place = "USA",
                    DateOfBirth = new DateTime(1988, 6, 9)
                }
                );
        }
    }
}
