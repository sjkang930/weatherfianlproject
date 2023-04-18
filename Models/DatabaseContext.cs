using Microsoft.EntityFrameworkCore;

namespace Weather.Models;
public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>()
        .Property(e => e.Created)
        .HasDefaultValueSql("now()");

    modelBuilder.Entity<WeatherData>()
        .Property(e => e.Created)
        .HasDefaultValueSql("now()");

    modelBuilder.Entity<FavoriteWeather>()
        .Property(e => e.Created)
        .HasDefaultValueSql("now()");
  }
  public DbSet<User> Users => Set<User>();
  public DbSet<WeatherData> WeatherDatas => Set<WeatherData>();
  public DbSet<FavoriteWeather> FavoriteWeathers => Set<FavoriteWeather>();
}