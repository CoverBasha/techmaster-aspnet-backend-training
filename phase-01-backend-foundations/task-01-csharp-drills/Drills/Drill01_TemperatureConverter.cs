namespace task_01_csharp_drills.Drills
{
    public class Drill01_TemperatureConverter
    {
        public static void ConvertToFahrenheit()
        {
            while(true)
            {
                Console.WriteLine("Enter temperature in Celsius or type e to exit: ");
                var input = Console.ReadLine();
                if (input.ToLower() == "e")
                    return;

                if (!Decimal.TryParse(input, out decimal result))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.WriteLine();
                    continue;
                }

                var fahrenheit = (result * 9 / 5) + 32;

                Console.WriteLine($"{Decimal.Round(result, 2)}°C = {Decimal.Round(fahrenheit,2)}°F");
                Console.WriteLine();
            }
        }
    }
}
