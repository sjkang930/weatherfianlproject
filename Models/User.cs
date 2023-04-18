namespace Weather.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();

        public string Username { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }

        public DateTime? Created { get; set; } 

        public ICollection<FavoriteWeather>? FavoriteWeathers { get; set; }

        public ICollection<WeatherData>? WeatherDatas { get; set; }
    }
}
