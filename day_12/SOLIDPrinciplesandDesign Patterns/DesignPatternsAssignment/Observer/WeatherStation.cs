namespace DesignPatternsAssignment.Observer
{
    public class WeatherStation
    {
        private readonly List<IWeatherObserver> _observers = new();
        private float _temperature;

        public void Register(IWeatherObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IWeatherObserver observer)
        {
            _observers.Remove(observer);
        }

        public void SetTemperature(float temperature)
        {
            _temperature = temperature;
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_temperature);
            }
        }
    }
}
