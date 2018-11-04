using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LawyerApp.Models
{
    public class LawyerDbContext:IdentityDbContext<AppUser>
    {
        public LawyerDbContext(DbContextOptions<LawyerDbContext> dbContextOptions):base(dbContextOptions) { }


        public DbSet<Slider> Sliders { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<StaticData> StaticDatas { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<TeamToArea> TeamToAreas { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Holiday> Holidays { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<TeamToArea>().HasKey(c => new
            //{
            //    c.TeamMemberId,
            //    c.AreaId
            //});

            builder.Entity<TeamToArea>()
                .HasOne(m => m.Area)
                .WithMany(m => m.TeamToAreas)
                .HasForeignKey(m => m.AreaId);

            builder.Entity<TeamToArea>()
                .HasOne(m => m.TeamMember)
                .WithMany(m => m.TeamToAreas)
                .HasForeignKey(m => m.TeamMemberId);

            builder.Entity<Text>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Schedule>().Property(x => x.Id).HasDefaultValue(value: Guid.NewGuid());
            builder.Entity<Schedule>().Property(x => x.Acceept).HasDefaultValue(value: false);
            builder.Entity<Schedule>().Property(x => x.WorkOrNot).HasDefaultValue(value: false);
            builder.Entity<TeamMember>().Property(x => x.Begin).HasDefaultValue(value: 9);
            builder.Entity<TeamMember>().Property(x => x.End).HasDefaultValue(value: 6);
            builder.Entity<Schedule>().HasIndex(x => x.Date).IsUnique(unique: false);
            base.OnModelCreating(builder);
        }
    }

    
}
