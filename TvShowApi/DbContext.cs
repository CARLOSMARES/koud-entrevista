using Microsoft.EntityFrameworkCore;

public class TvShowContext : DbContext
{

    public DbSet<TvShow> TvShows { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    //     optionsBuilder.UseSqlServer("Server=tcp:tvshowserver.database.windows.net,1433;Initial Catalog=TvShow;Persist Security Info=False;User ID=CIOM;Password=Nachoc04042017@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
    // }

    public TvShowContext(DbContextOptions<TvShowContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelbuilder){
        modelbuilder.Entity<TvShow>(entity =>{
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Favorite).IsRequired();
        });
    }

}