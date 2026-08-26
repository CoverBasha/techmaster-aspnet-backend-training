namespace ApiRoutingDrills.Services
{
    public class GradeCalculatorService
    {
        public char? Calculate(int grade)
        {
            if(grade < 0 || grade > 100)
                return null;

            return grade switch
            {
                > 89 => 'A',
                > 79 => 'B',
                > 69 => 'C',
                > 59 => 'D',
                _ => 'F',
            };
        }
    }
}
