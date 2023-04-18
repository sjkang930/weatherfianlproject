namespace Weather.Models;
public class FavoriteWeather
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public ICollection<User>? Users { get; set; }
    public ICollection<WeatherData>? WeatherDatas { get; set; }
    public DateTime? Created { get; set; }
}