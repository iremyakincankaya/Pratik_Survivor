using Microsoft.EntityFrameworkCore;

namespace Pratik_Survivor.Data
{
    public class UygulamaDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Competitor> Competitors { get; set; }

        public UygulamaDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=postgre;Database=SurvivorDb"); //içine bağlantı cümlemizi gireceğiz
        }

        // OnModelCreating: veri tabanında olusturulacak verilerin modelini içerir, örnek verileri girmeye olanak sağlar . Mapping yapılır
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category() { Id = 1, CreatedDate = new 
                    DateTime(2024, 01, 01).ToUniversalTime(),
                    ModifiedDate = new DateTime(2024, 01, 02).ToUniversalTime(), 
                    IsDeleted = false, Name = "Ünlüler" },
                    new Category() { Id = 2, CreatedDate = new DateTime(2024, 01, 01).ToUniversalTime(),
                    ModifiedDate = new DateTime(2024, 01, 02).ToUniversalTime(),
                    IsDeleted = false, Name = "Gönüllüler" }
                );

            //has data hariç idler girilmez
            modelBuilder.Entity<Competitor>().HasData(
                new Competitor() {Id = 1, CreatedDate = new DateTime(2024, 01, 01).ToUniversalTime(),
                    ModifiedDate = new DateTime(2024, 01, 02).ToUniversalTime(),
                    IsDeleted = false,FirstName = "Aleyna",
                    LastName = "Avcı", CategoryId = 1},
                new Competitor() { Id = 2, CreatedDate = new DateTime(2024, 01, 01).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 02).ToUniversalTime(), IsDeleted = false, FirstName = "Hadise", LastName = "Açıkgöz", CategoryId = 1 },
                 new Competitor() { Id = 3, CreatedDate = new DateTime(2024, 01, 01).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 02).ToUniversalTime(), IsDeleted = false, FirstName = "Ahmet", LastName = "Yılmaz", CategoryId = 2 },
                 new Competitor() { Id = 4, CreatedDate = new DateTime(2024, 01, 01).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 02).ToUniversalTime(), IsDeleted = false, FirstName = "Ayşe", LastName = "Karaca", CategoryId = 2 }
                );
        }

    }
}
