using ApiRoutingDrills.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/converter")]
    [ApiController]
    public class TemperatureConversionController : ControllerBase
    {
        private readonly TemperatureConversionService converter;

        public TemperatureConversionController(TemperatureConversionService converter)
        {
            this.converter = converter;
        }

        [HttpGet("celsius-to-fahrenheit")]
        public IActionResult CelsiusToFahrenheit([FromQuery] decimal value)
        {
            var fahr = converter.CelsiusToFahrenheit(value);

            return Ok(new { Fahrenheit = fahr });
        }
    }
}
