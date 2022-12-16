using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NotQuiteHuman.Models;
using Microsoft.AspNetCore.Identity;

namespace NotQuiteHuman.Data
{
    public class NotQuiteHumanContext : IdentityDbContext<IdentityUser>
    {
        public NotQuiteHumanContext(DbContextOptions<NotQuiteHumanContext> options) : base(options) { }

        public DbSet<Race> Races { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AbilityScoreBonus> AbilityScoreBonus { get; set;}
        public DbSet<RaceLanguage> RaceLanguages { get; set; }
        public DbSet<RaceTrait> RaceTraits { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Race>().ToTable("Race");
            modelBuilder.Entity<Trait>().ToTable("Trait");
            modelBuilder.Entity<Language>().ToTable("Language");
            modelBuilder.Entity<AbilityScoreBonus>().ToTable("AbilityScoreBonus");
            modelBuilder.Entity<RaceLanguage>().ToTable("RaceLanguage");
            modelBuilder.Entity<RaceTrait>().ToTable("RaceTrait");
                
        }
        
    }
}
