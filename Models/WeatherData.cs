using System.ComponentModel.DataAnnotations.Schema;

namespace Weather.Models
{
    public class WeatherData
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Location { get; set; }

        public double? Temperature { get; set; }

        public double? Humidity { get; set; }

        public double? WindSpeed { get; set; }

        public string? Precipitation { get; set; }

        public double? rain { get; set; }

        public double? clouds { get; set; }

        public string? WeatherDescription { get; set; }

        public double? sunrise { get; set; }

        public double? sunset { get; set; }

        public double? feels_like { get; set; }

        public double? lat { get; set; }

        public double? lon { get; set; }

        public DateTime? Created { get; set; }

        public ICollection<FavoriteWeather>? FavoriteWeathers { get; set; }

       [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
