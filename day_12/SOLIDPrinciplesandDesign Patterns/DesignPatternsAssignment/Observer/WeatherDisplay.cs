namespace DesignPatternsAssignment.Observer
{
    public class WeatherDisplay : IWeatherObserver
    {
        public void Update(float temperature)
        {
            Console.WriteLine($"Temperature Updated: {temperature}°C");
        }
    }
}
