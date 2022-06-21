using Kolokwium_poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_poprawa.DataAccess
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<File> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<File>(p =>
            {
                p.HasKey(e => new { e.FileID, e.TeamID });
                p.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                p.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                p.Property(e => e.FileSize).IsRequired();

                p.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID);

                p.HasData(
                    new File { FileID = 1, FileName = "file1", FileExtension = ".jar", FileSize = 4, TeamID = 1 },
                     new File { FileID = 1, FileName = "file2", FileExtension = ".jar", FileSize = 4, TeamID = 2 }
                    );
            });

            modelBuilder.Entity<Organization>(m =>
            {
                m.HasKey(e => e.OrganizationID);
                m.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                m.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);

                m.HasData(
                    new Organization { OrganizationID = 1, OrganizationName = "OrgName1", OrganizationDomain = "Domain1" },
                    new Organization { OrganizationID = 2, OrganizationName = "OrgName2", OrganizationDomain = "Domain2" }
                    );

            });

            modelBuilder.Entity<Team>(p =>
            {
                p.HasKey(e => e.TeamID);
                p.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                p.Property(e => e.TeamDescription).HasMaxLength(500);

                p.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID);

                p.HasData(
                    new Team { TeamID = 1, TeamName = "Team1", TeamDescription = "Desc1", OrganizationID = 1 },
                    new Team { TeamID = 2, TeamName = "Team2", TeamDescription = "Desc2", OrganizationID = 2 }
                    );
            });

            modelBuilder.Entity<Member>(d =>
            {
                d.HasKey(e => e.MemberID);
                d.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                d.Property(e => e.MemberSurName).IsRequired().HasMaxLength(50);
                d.Property(e => e.MemberNickName).HasMaxLength(20);

                d.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID);

                d.HasData(
                    new Member { MemberID = 1, MemberName = "Member1", MemberSurName = "Surname1", MemberNickName = "Nick1", OrganizationID = 1 },
                    new Member { MemberID = 1, MemberName = "Member2", MemberSurName = "Surname2", MemberNickName = "Nick2", OrganizationID = 2 }
                    );
            });


            modelBuilder.Entity<Membership>(m =>
            {
                m.HasKey(e => new { e.MemberID, e.TeamID });
                m.Property(e => e.MembershipDate).IsRequired();

                m.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID);
                m.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamID);

                m.HasData(
                    new Membership { MemberID = 1, TeamID = 1, MembershipDate = System.DateTime.MaxValue },
                    new Membership { MemberID = 2, TeamID = 2, MembershipDate = System.DateTime.MaxValue }
                    );
            });
        }
    }
}
