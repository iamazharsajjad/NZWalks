using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;
namespace NZWalksAPI.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Difficulty Data for Difficulties Table
            var difficultyEntity = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Name = "Hard"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficultyEntity);

            //Seed Region Data for Regions Table

            var regionEntity = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("1e1f5e5e-5e5e-4e4e-8e8e-1e1f5e5e5e5e"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://example.com/auckland.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("2f2f6f6f-6f6f-4f4f-9f9f-2f2f6f6f6f6f"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "https://example.com/wellington.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("3a3a7a7a-7a7a-4a4a-afaf-3a3a7a7a7a7a"),
                    Name = "Christchurch",
                    Code = "CHC",
                    RegionImageUrl = "https://example.com/christchurch.jpg"
                },
            };
            modelBuilder.Entity<Region>().HasData(regionEntity);
        }
    } 
}
