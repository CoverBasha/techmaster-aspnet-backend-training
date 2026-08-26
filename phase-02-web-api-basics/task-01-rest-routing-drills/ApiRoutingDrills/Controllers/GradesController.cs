using ApiRoutingDrills.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly GradeCalculatorService calculator;

        public GradesController(GradeCalculatorService calculator)
        {
            this.calculator = calculator;
        }

        [HttpGet("calculate")]
        public IActionResult CalculateGrade([FromQuery] int score)
        {
            var Grade = calculator.Calculate(score);

            return Grade == null ? BadRequest() : Ok(new { Grade });
        }
    }
}
