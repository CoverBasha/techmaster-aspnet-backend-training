namespace ApiRoutingDrills.Services
{
    public class TemperatureConversionService
    {
        public decimal CelsiusToFahrenheit(decimal celsius)
        {
            var fahrenheit = (9 * celsius / 5) + 32;
            return fahrenheit;
        }
    }
}
